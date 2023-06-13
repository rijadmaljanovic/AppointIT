using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;
using AppointIT.Model.Models;

namespace AppointIT.Controllers
{
    [Authorize]

    public class ServiceRatingController : CrudController<ServiceRating, ServiceRatingSearchObject, ServiceRatingInsertRequest, ServiceRatingInsertRequest>
    {
        public ServiceRatingController(IServiceRatingService _service) : base(_service)
        {

        }

    }
}
