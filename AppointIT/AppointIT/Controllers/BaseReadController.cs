﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppointIT.Services.Interfaces;
using static Microsoft.VisualStudio.Services.Notifications.VssNotificationEvent;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaseReadController<T,TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IReadService<T,TSearch> _service;
        public BaseReadController(IReadService<T, TSearch> service)
        {
            _service = service;
        }
        [HttpGet]
        public virtual IEnumerable<T> Get ([FromQuery]TSearch search)
        {
            return _service.Get(search);
        }
        [HttpGet("{Id}")]
        public virtual T GetById(int Id)
        {
            return _service.GetById(Id);
        }

    }
}
