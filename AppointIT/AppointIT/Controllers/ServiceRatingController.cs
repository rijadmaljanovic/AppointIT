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

    public class ServiceRatingController : CrudController<Model.Models.ServiceRating, ServiceRatingSearchObject, ServiceRatingInsertRequest, ServiceRatingInsertRequest>
    {
        IServiceRatingService service;
        public ServiceRatingController(IServiceRatingService _service) : base(_service)
        {
            this.service = _service;
        }
        [HttpGet("/GetLastService")]
        public virtual int GetLastService()
        {
            return service.GetLastService();
        }
    }
}
