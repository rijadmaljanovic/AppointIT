using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model;
using Microsoft.EntityFrameworkCore;

using AppointIT.Model.Requests;

namespace AppointIT.Services
{
    public class SalonService : CrudService<Model.Salon, Database.Salon, SalonSearchObject, SalonInsertRequest, SalonInsertRequest>, ISalonService
    {
        public SalonService(MyContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override  IEnumerable<Model.Salon> Get(SalonSearchObject search = null)
        {
            var entity = _context.Set<Database.Salon>().AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
                entity = entity.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }


            var list = entity.ToList();

            return _mapper.Map<List<Model.Salon>>(list);
        }

    }
}
