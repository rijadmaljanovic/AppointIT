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
    public  class ServiceRatingService : CrudService<Model.Models.ServiceRating, Database.ServiceRating, ServiceRatingSearchObject, ServiceRatingInsertRequest, ServiceRatingInsertRequest>, IServiceRatingService
    {
        public ServiceRatingService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public int GetLastService()
        {
            var lastService = _context.ServiceRatings.OrderByDescending(sr => sr.ServiceRatingId).FirstOrDefault();

            return lastService?.ServiceId ?? 0;
        }
    }
}
