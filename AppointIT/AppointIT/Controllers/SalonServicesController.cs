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
    public class SalonServicesController : CrudController<SalonServices, SalonServicesSearchObject, SalonServices, object>
    {
        public SalonServicesController(ISalonServicesService service) : base(service)
        {
        }
    }
}


