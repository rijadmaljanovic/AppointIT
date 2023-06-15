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

        [HttpGet("{SalonId}")]
        public IActionResult RecommendedSalon(int SalonId)
        {
            try
            {
                return Ok(service.Recommend(SalonId));
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
