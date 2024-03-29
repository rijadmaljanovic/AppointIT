﻿using AutoMapper;
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
        public List<SalonCustom> SearchFilter(TermCustomSearchObject search = null)
        {
            if (search != null)
            {
                var query = from t in _context.Terms
                            join s in _context.Services on t.ServiceId equals s.Id
                            join e in _context.Employees on t.EmployeeId equals e.Id
                            join sa in _context.Salons on e.SalonId equals sa.Id
                            join ci in _context.Cities on sa.CityId equals ci.Id
                            where ((!string.IsNullOrEmpty(search.ServiceName) && s.Name.ToLower().Contains(search.ServiceName.ToLower())) ||
                            string.IsNullOrEmpty(search.ServiceName)) && ((!string.IsNullOrEmpty(search.Location) && sa.Location.Contains(search.Location) ||
                            ci.Name.Contains(search.Location)) || string.IsNullOrEmpty(search.Location)) && ((search.Date.HasValue && t.Date == search.Date.Value.Date) || search.Date == null)
                            select new
                            {
                                SalonId = sa.Id,
                                SalonName = sa.Name,
                                SalonPhoto = sa.Photo,
                                CityName = ci.Name,
                                Location = sa.Location,
                                ServiceName = s.Name,
                                ServicePrice = s.Price,
                                ServiceId = s.Id,
                            };

                List<SalonCustom> list = new List<SalonCustom>();
                var listWithSalons = query.ToLookup(x => new { SalonId = x.SalonId, x.SalonName, x.SalonPhoto, x.Location, x.CityName }).ToList();


                foreach (var item in listWithSalons.GroupBy(x => x.Key.SalonId))
                {
                    list.Add(new SalonCustom
                    {
                        SalonId = item.Key,
                        services = new List<ServiceCustom>()
                    });
                }

                foreach (var x in query.Distinct())
                {
                    foreach (var f in list)
                    {
                        if (x.SalonId == f.SalonId)
                        {
                            f.SalonName = x.SalonName;
                            f.SalonPhoto = x.SalonPhoto;
                            f.Location = x.Location;
                            f.CityName = x.CityName;
                            f.services.Add(new ServiceCustom { ServiceId = x.ServiceId, ServiceName = x.ServiceName, ServicePrice = x.ServicePrice.Value });
                        }
                    }
                }

                return list;
            }
            return null;
        }
        public class SalonCustom
        {
            public int SalonId { get; set; }
            public string SalonName { get; set; }
            public byte[] SalonPhoto { get; set; }
            public string CityName { get; set; }
            public string Location { get; set; }
            public List<ServiceCustom> services { get; set; }
        }

        public class ServiceCustom
        {
            public int ServiceId { get; set; }
            public string ServiceName { get; set; }
            public decimal ServicePrice { get; set; }
            public DateTime TermDate { get; set; }
            public int TermId { get; set; }
        }
    }
}
