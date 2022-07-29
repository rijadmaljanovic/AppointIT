using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;

namespace AppointIT.Services
{
    public class CityService : ReadService<Model.Models.City, Database.City, object>, ICityService
    {
        public CityService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
