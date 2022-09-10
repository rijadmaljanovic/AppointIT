using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using static AppointIT.Services.TermCustomService;
using AppointIT.Model.Models;

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
        public virtual TermCustom Get(int id)
        {
            return _service.Get(id);
        }
    }
}
