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
    public class CustomerService : CrudService<Model.Models.Customer, Database.Customer, CustomerSearchObject, object, object>, ICustomerService
    {
        public CustomerService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.Models.Customer> Get(CustomerSearchObject search)
        {
            if (search!=null && search.ReportData)
                return GetDataForReport(search);

            var entity = _context.Set<Database.Customer>().AsQueryable();
            entity = entity.Include("BaseUser");

            if (!string.IsNullOrEmpty(search?.Email))
                entity= entity.Include(x => x.BaseUser).Where(x => x.BaseUser.Email == search.Email);

             var list = entity.ToList();

            return _mapper.Map<List<Model.Models.Customer>>(list);
        }
        private List<Model.Models.Customer> GetDataForReport(CustomerSearchObject search)
        {
            var query = from t in _context.Terms
                        join c in _context.Customers on t.CustomerId equals c.Id
                        join bu in _context.BaseUsers on c.Id equals bu.Id
                        join e in _context.Employees on t.EmployeeId equals e.Id
                        where e.SalonId == search.SalonId
                        group new { bu } by new { bu.FirstName,bu.LastName,bu.Id,bu.PhoneNumber} into g
                        select new{ FirstName = g.Key.FirstName, LastName = g.Key.LastName, Count = g.Count(), Id = g.Key.Id,Phone=g.Key.PhoneNumber };

            List<Model.Models.Customer> list = query.OrderByDescending(x => x.Count).Select(x => new Model.Models.Customer { Id = x.Id, BaseUser = new Model.Models.BaseUser { FirstName=x.FirstName,LastName=x.LastName,Id=x.Id,PhoneNumber=x.Phone}}).Take(5).ToList();

            return list;
        }

    }
}