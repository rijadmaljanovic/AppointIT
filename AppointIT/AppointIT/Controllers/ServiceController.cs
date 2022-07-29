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
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class ServiceController : CrudController<Service, ServiceSearchObject, ServiceInsertRequest, ServiceInsertRequest>
    {
        public ServiceController(IServiceService _service ):base(_service)
        {

        }
        

    }
}
