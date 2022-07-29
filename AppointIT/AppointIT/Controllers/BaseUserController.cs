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
    public class BaseUserController : ControllerBase
    {
        private IBaseUserService _service;
        public BaseUserController(IBaseUserService _service)
        {
            this._service = _service;
        }
        [HttpGet("{id}")]
        public BaseUser GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        [Authorize]
        public BaseUser Insert(BaseUserInsertRequest users)
        {
            return _service.Insert(users);
        }
        [HttpGet]
        [Authorize]
        public IEnumerable<BaseUser> Get()
        {
            return _service.GetAll();
        }
        [HttpPut("{id}")]
        [Authorize]

        public BaseUser Update(int Id, BaseUserInsertRequest request)
        {
            return _service.Update(Id, request);
        }
        [HttpPost("Register")]
        public BaseUser Register(BaseUserInsertRequest request)
        {
            return _service.Register(request);
        }
    }
}
