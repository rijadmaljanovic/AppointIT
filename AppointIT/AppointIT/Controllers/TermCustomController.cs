using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using AppointIT.Model;
using static AppointIT.Services.TermCustomService;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class TermCustomController :ControllerBase
    {
        private ITermCustomService _service;
        public TermCustomController(ITermCustomService service)
        {
            _service = service;
        }
        [HttpGet]
        public virtual IEnumerable<SalonCustom> Get([FromQuery] TermCustomSearchObject search)
        {
            return _service.GetAll(search);
        }
    }
}
