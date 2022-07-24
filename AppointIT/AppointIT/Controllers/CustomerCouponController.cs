using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;

namespace AppointIT.Controllers
{
    [Authorize]
    public class CustomerCouponController : CrudController<Model.CustomerCoupon, CustomerCouponSearchObject, CustomerCouponInsertRequest, CustomerCouponInsertRequest>
    {
        public CustomerCouponController(ICustomerCouponsService _service) : base(_service)
        {

        }
    }
}
