using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace AppointIT.Services
{
    public class CustomerRecommenderService : ICustomerRecommenderService
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        private static readonly object isLocked = new object();
        private static MLContext mlContext;
        private static ITransformer model;

        public CustomerRecommenderService( MyContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        public List<Model.Models.CustomerServiceRecommend> Recommend(int customerId)
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var customerSearchHistory = _context.CustomerSearchHistories
                        .Include(x => x.Service)
                        .Where(x => x.CustomerId == customerId)
                        .ToList();

                    var searchHistoryData = customerSearchHistory.Select(x => new InputData
                    {
                        CustomerId = (uint)x.CustomerId,
                        ServiceName = x.Service.Name
                    }).ToList();

                    var dataView = mlContext.Data.LoadFromEnumerable(searchHistoryData);

                    var pipeline = mlContext.Transforms.Conversion
                        .MapValueToKey("ServiceName")
                        .Append(mlContext.Transforms.Categorical.OneHotEncoding("ServiceName"))
                        .Append(mlContext.Transforms.NormalizeMinMax("ServiceName"))
                        .Append(mlContext.Clustering.Trainers.KMeans("ServiceName", numberOfClusters: 3));

                    model = pipeline.Fit(dataView);
                }
            }

            var predictionResult = new List<Model.Models.CustomerServiceRecommend>();

            var predictionEngine = mlContext.Model.CreatePredictionEngine<InputData, OutputData>(model);

            var customerSearchHistoryServiceNames = _context.CustomerSearchHistories
               .Include(x => x.Service)
               .Where(x => x.CustomerId == customerId)
               .Select(x => x.Service.Name)
               .ToList();

            List<Database.Service> allServices = _context.Services
                .Where(x => customerSearchHistoryServiceNames.Contains(x.Name))
                .ToList();

            var customerHistory = _context.CustomerSearchHistories
               .Include(x => x.Service)
               .ThenInclude(x => x.SalonServices)
               .Where(x => x.CustomerId == customerId)
               .ToList();

            if (customerHistory.Count > 0)
            {
                var lastService = customerHistory.OrderByDescending(x => x.Id).First();
                var lastServicePrediction = predictionEngine.Predict(new InputData { ServiceName = lastService.Service.Name });

                foreach (var service in allServices)
                {
                    var prediction = predictionEngine.Predict(new InputData()
                    {
                        ServiceName = service.Name,
                    });

                    if (prediction.PredictedClusterId == lastServicePrediction.PredictedClusterId)
                    {
                        predictionResult.Add(new Model.Models.CustomerServiceRecommend()
                        {
                            ServiceId = service.Id,
                            CustomerId = customerId,
                            ServiceName = service.Name,
                            ServicePrice = service.Price
                        });
                    }
                }
            }
            return predictionResult.OrderBy(x => x.ServicePrice).ToList();
        }

        public class InputData
        {
            public uint CustomerId;
            public string ServiceName { get; set; }
        }

        public class OutputData
        {
            [ColumnName("PredictedLabel")]
            public uint PredictedClusterId;
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

                            if (search?.CustomerId != null)
                            {
                                _context.CustomerSearchHistories.Add(new Database.CustomerSearchHistory { CustomerId = search.CustomerId.Value, ServiceId = x.ServiceId });
                            }
                        }
                    }
                }

                if (search?.CustomerId != null)
                        _context.SaveChanges();

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
}
