using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace AppointIT.Services.Database
{
    public class CustomerCoupon
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public  Customer Customer { get; set; }
        public int CouponId { get; set; }
        public  Coupon Coupon { get; set; }
        public bool IsUsed { get; set; }

    }
}
