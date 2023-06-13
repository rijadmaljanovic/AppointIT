using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointIT.Services
{
    public class CustomerRecommenderService : ICustomerRecommenderService
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        Dictionary<int, List<Database.ServiceRating>> services = new Dictionary<int, List<Database.ServiceRating>>();

        public CustomerRecommenderService(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private List<Database.Service> LoadSimilar(int serviceId)
        {
            LoadOtherServices(serviceId);
            List<Database.ServiceRating> ratingOfCurrent = _context.ServiceRatings.Where(x => x.ServiceId == serviceId).OrderBy(x => x.CustomerId).ToList();

            List<Database.ServiceRating> ratings1 = new List<Database.ServiceRating>();
            List<Database.ServiceRating> ratings2 = new List<Database.ServiceRating>();
            List<Database.Service> recommendedServices= new List<Database.Service>();

            foreach (var service in services)
            {
                foreach (Database.ServiceRating rating in ratingOfCurrent)
                {
                    if (service.Value.Where(w => w.CustomerId == rating.CustomerId).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(service.Value.Where(w => w.CustomerId == rating.CustomerId).First());
                    }
                }
                double similarity = GetSimilarity(ratings1, ratings2);
                if (similarity > 0.5)
                {
                    recommendedServices.Add(_context.Services.AsQueryable().Where(w => w.Id == service.Key).FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }
            return recommendedServices;
        }

        private double GetSimilarity(List<Database.ServiceRating> ratings1, List<Database.ServiceRating> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }
            double x = 0, y1 = 0, y2 = 0;

            for (int i = 0; i < ratings1.Count; i++)
            {
                x += ratings1[i].Rating * ratings2[i].Rating;
                y1 += ratings1[i].Rating * ratings1[i].Rating;
                y2 += ratings2[i].Rating * ratings2[i].Rating;
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }

        private void LoadOtherServices(int serviceId)
        {
            List<Database.Service> list = _context.Services.Where(w => w.Id != serviceId).ToList();
            List<Database.ServiceRating> ratings = new List<Database.ServiceRating>();
            foreach (var item in list)
            {
                ratings = _context.ServiceRatings.Where(w => w.ServiceId == item.Id).OrderBy(w => w.ServiceId).ToList();
                if (ratings.Count > 0)
                {
                    services.Add(item.Id, ratings);
                }
            }

        }

        public List<Model.Models.Service> Recommend(int serviceId)
        {
            var tmp = LoadSimilar(serviceId);
            return _mapper.Map<List<Model.Models.Service>>(tmp);
        }
    }
}