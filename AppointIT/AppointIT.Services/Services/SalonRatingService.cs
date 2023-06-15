using AppointIT.Model.Requests;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AutoMapper;
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
        public int GetLastSalon()
        {
            var lastService = _context.SalonRatings.OrderByDescending(sr => sr.SalonRatingId).FirstOrDefault();

            return lastService?.SalonId ?? 0;
        }
    }
}
