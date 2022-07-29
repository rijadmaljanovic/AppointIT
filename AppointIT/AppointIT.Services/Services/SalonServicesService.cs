using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;

namespace AppointIT.Services
{
    public class SalonServicesService : CrudService<Model.Models.SalonServices, Database.SalonServices, SalonServicesSearchObject, Model.Models.SalonServices,object>, ISalonServicesService
    {
        public SalonServicesService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.Models.SalonServices> Get(SalonServicesSearchObject search)
        {
            var entity = _context.Set<Database.SalonServices>().AsQueryable();

            if (search?.SalonId != null)
                entity = entity.Where(x => x.SalonId==search.SalonId);


            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }
            var list = entity.ToList();

            return _mapper.Map<IEnumerable<Model.Models.SalonServices>>(list);
        }
    }
}
