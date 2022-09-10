using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;
using AppointIT.Model.Models;

namespace AppointIT.Services
{
    public class CouponService : CrudService<Model.Models.Coupon, Database.Coupon, CouponSearchObject, CouponInsertRequest, CouponInsertRequest>, ICouponService
    {
        public CouponService(MyContext context, IMapper mapper) : base(context, mapper) { }
        public override IEnumerable<Model.Models.Coupon> Get(CouponSearchObject search = null)
        {
            var entity = _context.Set<Database.Coupon>().AsQueryable();
            entity = entity.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now);

            var customerCouponEntity = _context.Set<Database.CustomerCoupon>().AsQueryable();

            if (search?.CustomerId != null)
                customerCouponEntity = customerCouponEntity.Where(x => x.CustomerId == search.CustomerId);

            var list = entity.ToList();
            var customerCouponList = customerCouponEntity.ToList();

            var mergeList = list.Where(x => !customerCouponList.Any(y => y.CouponId == x.Id)).ToList();
            //active coupons
            return _mapper.Map<List<Model.Models.Coupon>>(mergeList);
        }

    }
}
