using AppointIT.Model.Models;
using AppointIT.Model.Requests;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppointIT.Services.Services
{
    public  class SalonRatingService : CrudService<Model.Models.SalonRating, Database.SalonRating, SalonRatingSearchObject, SalonRatingInsertRequest, SalonRatingInsertRequest>, ISalonRatingService
    {
        private readonly ICustomerRecommenderService _customerRecommenderService;
        public SalonRatingService(MyContext context, IMapper mapper, ICustomerRecommenderService customerRecommenderService) : base(context, mapper)
        {
            _customerRecommenderService = customerRecommenderService;
        }

        public override Model.Models.SalonRating Insert(SalonRatingInsertRequest salonRating)
        {
            var insertedSalonRating = base.Insert(salonRating);

            Task.Run(() => _customerRecommenderService.CreateModel());

            return insertedSalonRating;
        }

        public override List<Model.Models.SalonRating> Get(SalonRatingSearchObject search)
        {
            var query = _context.SalonRatings.Include(x => x.Salon).Include(x => x.Customer).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.SalonId.ToString()))
            {
                query = query.Where(x => x.SalonId == search.SalonId);
            }

            if (!string.IsNullOrWhiteSpace(search?.CustomerId.ToString()))
            {
                query = query.Where(x => x.CustomerId == search.CustomerId);
            }



            var list = query.ToList();
            return _mapper.Map<List<Model.Models.SalonRating>>(list);
        }

        public int GetLastSalon(int id)
        {
            var lastSalonId = _context.SalonRatings
                .Where(r => r.CustomerId == id)
                .OrderByDescending(r => r.RatingDate)
                .Select(r => r.SalonId)
                .FirstOrDefault();

            return lastSalonId;
        }
    }
}
