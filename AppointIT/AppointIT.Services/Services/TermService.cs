﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Model.Requests;
using AppointIT.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AppointIT.Services
{
    public class TermService: CrudService<Model.Term, Database.Term, Model.TermSearchObject, TermInsertRequest, TermInsertRequest>, ITermService
    {
        public TermService(MyContext context, IMapper mapper) : base(context, mapper) { }

        public override IEnumerable<Model.Term> Get(Model.TermSearchObject search)
        {
            var entity = _context.Set<Database.Term>().AsQueryable();

            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }
            if (search.ServiceId.HasValue)
                entity = entity.Where(x => x.ServiceId == search.ServiceId.Value);

            if (search?.SalonId != null && !search.IsReport && search.SalonId != 0)
                entity = entity.Include(x => x.Employee).Where(x => x.Employee.SalonId == search.SalonId);

            if (search.Date.HasValue)
                entity = entity.Where(x => x.Date.Value.Date == search.Date);

            if (search?.CustomerId != null)
                entity = entity.Where(x => x.CustomerId == search.CustomerId && x.Reserved == true);

            if (search.CustomerId == null)
                entity = entity.Where(x => x.Reserved == false);

            var list = entity.OrderBy(x => x.StartTime).ToList();
            return _mapper.Map<List<Model.Term>>(list);
        }


    }
}
