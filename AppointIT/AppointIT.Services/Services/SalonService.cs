using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

using AppointIT.Model.Requests;
using AppointIT.Model.Models;

namespace AppointIT.Services
{
    public class SalonService : CrudService<Model.Models.Salon, Database.Salon, SalonSearchObject, SalonInsertRequest, SalonInsertRequest>, ISalonService
    {
        public SalonService(MyContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override  IEnumerable<Model.Models.Salon> Get(SalonSearchObject search = null)
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

            return _mapper.Map<List<Model.Models.Salon>>(list);
        }

    }
}
