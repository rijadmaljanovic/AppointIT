﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;

namespace AppointIT.Services
{
    public class ServiceService : CrudService<Model.Service, Database.Service, Model.ServiceSearchObject, ServiceInsertRequest, ServiceInsertRequest>, IServiceService
    {
        public ServiceService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.Service> Get(Model.ServiceSearchObject search)
        {
            if (search?.SalonId != null )
                return GetDataForReport(search?.SalonId);

            var entity = _context.Set<Database.Service>().AsQueryable();

            if (search?.CategoryId != null)
                entity = entity.Where(x => x.CategoryId == search.CategoryId);


            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Service>>(list);
        }
        private List<Model.Service> GetDataForReport(int? SalonId)
        {

            var query = from t in _context.Terms
                        join s in _context.Services on t.ServiceId equals s.Id
                        join e in _context.Employees on t.EmployeeId equals e.Id
                        where e.SalonId == SalonId
                        group new { s } by new { s.Name, s.Price, s.Duration, s.Id } into g
                        select new { Name = g.Key.Name, Price = g.Key.Price, Duration = g.Key.Duration, Count = g.Count(),Id=g.Key.Id };

            List<Model.Service >list = query.OrderByDescending(x => x.Count).Select(x => new Model.Service{ Id = x.Id, Name = x.Name, Duration = x.Duration, Price = x.Price }).ToList();

            return list;
        }

        public override bool Delete(int Id)
        {
            try
            {
                var salonService = _context.SalonServices.FirstOrDefault(x => x.ServiceId == Id);
                _context.Remove(salonService);

                var service = _context.Services.Find(Id);
                _context.Remove(service);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }
}
