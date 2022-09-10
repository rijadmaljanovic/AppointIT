using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;
using static AppointIT.Services.CustomerRecommenderService;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerRecommenderController : ControllerBase
    {
        private readonly ICustomerRecommenderService service;
        public CustomerRecommenderController(ICustomerRecommenderService service)
        {
            this.service = service;
        }

        [HttpGet("{CustomerId}")]
        public List<CustomerServiceRecommend> GetRecommend(int CustomerId) 
        {
            return service.Get(CustomerId);
        }
         

        [HttpGet]
        public virtual IEnumerable<SalonCustom> Get([FromQuery] TermCustomSearchObject search)
        {
            return service.Recommender(search);
        }

    }
}
