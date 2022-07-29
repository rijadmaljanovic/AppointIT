using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Models
{
    public class CustomerCoupon
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public bool IsUsed { get; set; }
        public int MyProperty { get; set; }
        public string Title
        {
            get { return Coupon?.Title; }
        }
        public decimal? Value
        {
            get { return Coupon?.Value; }
        }
    }
}
