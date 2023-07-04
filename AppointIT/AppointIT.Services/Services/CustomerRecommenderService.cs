using AutoMapper;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.VisualStudio.Services.Common;

namespace AppointIT.Services
{
    public class CustomerRecommenderService : ICustomerRecommenderService
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public CustomerRecommenderService(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Models.Salon> Recommend(int salonId)
        {
            if(salonId == 0)
            {
                var bestRatedSalons = _context.Salons
                   .OrderByDescending(s => s.SalonRatings.Average(r => r.Rating))
                   .Take(5)
                   .ToList();

                return _mapper.Map<List<Model.Models.Salon>>(bestRatedSalons);
            }

            var salon = _context.Salons.FirstOrDefault(s => s.Id == salonId);

            if(salon == null) throw new Exception("Salon does not exist.");

            var mlContext = new MLContext();

            var model = LoadModel(mlContext);

            var salonIds = _context.Salons
                            .Select(x => x.Id)
                            .ToList();

            var recommendedsalonIds = GetSalonPredictions(mlContext, model, salonId, salonIds);

            var recommendedSalons = _context.Salons
                .Where(s => recommendedsalonIds.Contains(s.Id))
                .ToList();

            return _mapper.Map<List<Model.Models.Salon>>(recommendedSalons);
        }

        List<int> GetSalonPredictions(MLContext mlContext, ITransformer model, int salonId, List<int> salonIds)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<SalonRatingEntry, SalonRatingPrediction>(model);
            var predictionList = new List<SalonRatingPrediction>();

            foreach (var salon in salonIds)
            {
                var testInput = new SalonRatingEntry { SalonId = salonId, CoRatedSalonId = salon };

                var prediction = predictionEngine.Predict(testInput);
                prediction.SalonId = salon;

                predictionList.Add(prediction);
            }

            return predictionList
                .OrderByDescending(p => p.Score)
                .Take(3)
                .Select(p => p.SalonId)
                .ToList();
        }

        ITransformer LoadModel(MLContext mlContext)
        {
            DataViewSchema modelSchema;

            var modelPath = Path.Combine(Environment.CurrentDirectory, "SalonRecommenderModel.zip");

            ITransformer trainedModel = mlContext.Model.Load(modelPath, out modelSchema);

            return trainedModel;
        }

        public async Task CreateModel()
        {
            var mlContext = new MLContext();

            var users = _context.Customers.Include(u => u.SalonRatings.Where(usr => usr.Rating >= 2)).ToList();
            var data = new List<SalonRatingEntry>();

            if(users != null)
            {
                users.ForEach(u =>
                {
                    if (u.SalonRatings.Count > 1)
                    {
                        var userServicesIds = u.SalonRatings.Select(usr => usr.SalonId).ToList();

                        userServicesIds.ForEach(usId =>
                        {
                            var relatedServices = u.SalonRatings.Where(usr => usr.SalonId != usId).ToList();

                            relatedServices.ForEach(rs =>
                            {
                                data.Add(new SalonRatingEntry
                                {
                                    SalonId = usId,
                                    CoRatedSalonId = rs.SalonId
                                });
                            });
                        });
                    }
                });
            }

            var trainingData = mlContext.Data.LoadFromEnumerable(data);

            ITransformer model = BuildAndTrainModel(mlContext, trainingData);

            SaveModel(mlContext, trainingData.Schema, model);
        }

        ITransformer BuildAndTrainModel(MLContext mlContext, IDataView trainingData)
        {
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "SalonIdEncoded",
                MatrixRowIndexColumnName = "CoRatedSalonIdEncoded",
                LabelColumnName = "Rating",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var pipeline = mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "SalonId",
                    outputColumnName: "SalonIdEncoded")
                .Append(mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "CoRatedSalonId",
                    outputColumnName: "CoRatedSalonIdEncoded")

                .Append(mlContext.Recommendation().Trainers.MatrixFactorization(options)));

            var model = pipeline.Fit(trainingData);

            return model;
        }

        void SaveModel(MLContext mlContext, DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "SalonRecommenderModel.zip");

            mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
        }

        public List<SalonCustom> SearchFilter(TermCustomSearchObject search = null)
        {
            if (search != null)
            {
                var query = from t in _context.Terms
                            join s in _context.Services on t.ServiceId equals s.Id
                            join e in _context.Employees on t.EmployeeId equals e.Id
                            join sa in _context.Salons on e.SalonId equals sa.Id
                            join ci in _context.Cities on sa.CityId equals ci.Id
                            where ((!string.IsNullOrEmpty(search.ServiceName) && s.Name.ToLower().Contains(search.ServiceName.ToLower())) ||
                            string.IsNullOrEmpty(search.ServiceName)) && ((!string.IsNullOrEmpty(search.Location) && sa.Location.Contains(search.Location) ||
                            ci.Name.Contains(search.Location)) || string.IsNullOrEmpty(search.Location)) && ((search.Date.HasValue && t.Date == search.Date.Value.Date) || search.Date == null)
                            select new
                            {
                                SalonId = sa.Id,
                                SalonName = sa.Name,
                                SalonPhoto = sa.Photo,
                                CityName = ci.Name,
                                Location = sa.Location,
                                ServiceName = s.Name,
                                ServicePrice = s.Price,
                                ServiceId = s.Id,
                            };

                List<SalonCustom> list = new List<SalonCustom>();
                var listWithSalons = query.ToLookup(x => new { SalonId = x.SalonId, x.SalonName, x.SalonPhoto, x.Location, x.CityName }).ToList();


                foreach (var item in listWithSalons.GroupBy(x => x.Key.SalonId))
                {
                    list.Add(new SalonCustom
                    {
                        SalonId = item.Key,
                        services = new List<ServiceCustom>()
                    });
                }

                foreach (var x in query.Distinct())
                {
                    foreach (var f in list)
                    {
                        if (x.SalonId == f.SalonId)
                        {
                            f.SalonName = x.SalonName;
                            f.SalonPhoto = x.SalonPhoto;
                            f.Location = x.Location;
                            f.CityName = x.CityName;
                            f.services.Add(new ServiceCustom { ServiceId = x.ServiceId, ServiceName = x.ServiceName, ServicePrice = x.ServicePrice.Value });
                        }
                    }
                }

                return list;
            }
            return null;
        }
        public class SalonCustom
        {
            public int SalonId { get; set; }
            public string SalonName { get; set; }
            public byte[] SalonPhoto { get; set; }
            public string CityName { get; set; }
            public string Location { get; set; }
            public List<ServiceCustom> services { get; set; }
        }

        public class ServiceCustom
        {
            public int ServiceId { get; set; }
            public string ServiceName { get; set; }
            public decimal ServicePrice { get; set; }
            public DateTime TermDate { get; set; }
            public int TermId { get; set; }
        }
    }

    public class SalonRatingEntry
    {
        public int SalonId { get; set; }

        public int CoRatedSalonId { get; set; }

        public float Rating { get; set; }
    }

    public class SalonRatingPrediction
    {
        public int SalonId { get; set; }
        public float Score { get; set; }
    }
}