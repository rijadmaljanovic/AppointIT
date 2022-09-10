using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;

namespace AppointIT.Services
{
    public class CustomerCouponsService : CrudService<Model.Models.CustomerCoupon, Database.CustomerCoupon, CustomerCouponSearchObject, CustomerCouponInsertRequest, CustomerCouponInsertRequest>, ICustomerCouponsService
    {
        public CustomerCouponsService(MyContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IEnumerable<Model.Models.CustomerCoupon> Get(CustomerCouponSearchObject search = null)
        {
            //coupons per cust
            var entity = _context.Set<Database.CustomerCoupon>().AsQueryable();

            if (search?.CouponId!=null)
                entity = entity.Where(x => x.CouponId == search.CouponId);

            if (search?.CustomerId != null)
                entity = entity.Where(x => x.CustomerId == search.CustomerId);

            entity = entity.Include("Coupon");
            var list = entity.ToList();

            return _mapper.Map<List<Model.Models.CustomerCoupon>>(list);
        }

    }
}
