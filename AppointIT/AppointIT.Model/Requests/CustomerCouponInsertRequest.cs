using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Requests
{
    public class CustomerCouponInsertRequest
    {
        public int CustomerId { get; set; }
        public int CouponId { get; set; }
        public bool IsUsed { get; set; }
    }
}
