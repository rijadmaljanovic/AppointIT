using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;
using static AppointIT.Services.CustomerRecommenderService;
using static AppointIT.Services.SalonService;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerRecommenderController : ControllerBase
    {
        private readonly ICustomerRecommenderService _recommenderService;
        private readonly ISalonService _salonService;
        public CustomerRecommenderController(ICustomerRecommenderService recommenderService, ISalonService salonService)
        {
            _recommenderService = recommenderService;
            _salonService = salonService;
        }

        [HttpGet("{SalonId}")]
        public IActionResult RecommendedSalon(int SalonId)
        {
            try
            {
                return Ok(_recommenderService.Recommend(SalonId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public virtual IEnumerable<SalonCustom> Get([FromQuery] TermCustomSearchObject search)
        {
            return _salonService.SearchFilter(search);
        }
    }

}
