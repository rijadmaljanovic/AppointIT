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
            //if the customer did not have any ratings for any salon then best rated salons will be returned
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
                .Where(x=> x.Id != salonId)
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

            var predictionResult = new List<Tuple<int, float>>();

            salonIds.ForEach(id =>
            {
                var prediction = predictionEngine.Predict(new SalonRatingEntry()
                {
                    SalonId = (uint)salonId,
                    CoRatedSalonId = (uint)id
                });

                predictionResult.Add(new Tuple<int, float>(id, prediction.Score));
            });

            return predictionResult.OrderByDescending(pr => pr.Item2)
               .Select(pr => pr.Item1).Take(3).ToList();
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
            var users = _context.Customers.Include(u => u.SalonRatings.Where(usr => usr.Rating >= 3)).ToList();
            var data = new List<SalonRatingEntry>();

            if(users != null)
            {
                users.ForEach(u =>
                {
                    if (u.SalonRatings.Count > 1)
                    {
                        var userSalonIds = u.SalonRatings.Select(usr => usr.SalonId).ToList();

                        userSalonIds.ForEach(usId =>
                        {
                            var relatedSalons = u.SalonRatings.Where(usr => usr.SalonId != usId).ToList();

                            relatedSalons.ForEach(rs =>
                            {
                                data.Add(new SalonRatingEntry
                                {
                                    SalonId = (uint)usId,
                                    CoRatedSalonId = (uint)rs.SalonId
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
                MatrixColumnIndexColumnName = nameof(SalonRatingEntry.SalonId),
                MatrixRowIndexColumnName = nameof(SalonRatingEntry.CoRatedSalonId),
                LabelColumnName = "Label",

                LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                Alpha = 0.01,
                Lambda = 0.025,

                NumberOfIterations = 100,
                C = 0.00001
            };
            
            var pipeline = mlContext.Recommendation().Trainers.MatrixFactorization(options);

            var model = pipeline.Fit(trainingData);

            return model;
        }

        void SaveModel(MLContext mlContext, DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "SalonRecommenderModel.zip");

            mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
        }

    }

    public class SalonRatingEntry
    {
        [KeyType(count: 100)]
        public uint SalonId { get; set; }
        [KeyType(count: 100)]
        public uint CoRatedSalonId { get; set; }
        public float Label { get; set; }
    }

    public class SalonRatingPrediction
    {
        public float Score { get; set; }
    }
}