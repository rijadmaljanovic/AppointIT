using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SalonServicesController : CrudController<Model.SalonServices, Model.SalonServicesSearchObject, Model.SalonServices,object>
    {
        public SalonServicesController(ISalonServicesService service) : base(service)
        {
        }
    }
}


