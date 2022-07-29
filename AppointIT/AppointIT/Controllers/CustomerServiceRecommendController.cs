using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerServiceRecommendController : ControllerBase
    {
        private readonly ICustomerServiceRecommendService service;
        public CustomerServiceRecommendController(ICustomerServiceRecommendService service)
        {
            this.service = service;
        }
        [HttpGet("{CustomerId}")]
        public List<CustomerServiceRecommend> Get(int CustomerId) {
            return service.Get(CustomerId);
        }

    }
}
