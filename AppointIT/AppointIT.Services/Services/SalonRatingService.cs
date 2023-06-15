using AppointIT.Model.Requests;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public SalonRatingService(MyContext context, IMapper mapper) : base(context, mapper)
        {
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
        public int GetLastSalon()
        {
            var lastService = _context.SalonRatings.OrderByDescending(sr => sr.SalonRatingId).FirstOrDefault();

            return lastService?.SalonId ?? 0;
        }
    }
}
