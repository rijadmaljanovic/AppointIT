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

        [HttpGet]
        public IActionResult RecommendedProduct(int id)
        {
            try
            {
                return Ok(service.Recommend(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }

}
