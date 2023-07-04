using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;
using AppointIT.Model.Models;
using AppointIT.Services.Database;
using static AppointIT.Services.CustomerRecommenderService;

namespace AppointIT.Controllers
{
    [Authorize]

    public class SalonRatingController : CrudController<Model.Models.SalonRating, SalonRatingSearchObject, SalonRatingInsertRequest, SalonRatingInsertRequest>
    {
        ISalonRatingService service;
        public SalonRatingController(ISalonRatingService _service) : base(_service)
        {
            this.service = _service;
        }
        [HttpGet("/GetLastRatedSalon")]
        public virtual int GetLastSalon(int id)
        {
            return service.GetLastSalon(id);
        }
    }
}
