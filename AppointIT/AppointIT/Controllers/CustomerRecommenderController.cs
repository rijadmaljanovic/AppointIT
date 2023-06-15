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

        [HttpGet("{ServiceId}")]
        public IActionResult RecommendedProduct(int ServiceId)
        {
            try
            {
                return Ok(service.Recommend(ServiceId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public virtual IEnumerable<SalonCustom> Get([FromQuery] TermCustomSearchObject search)
        {
            return service.SearchFilter(search);
        }
    }

}
