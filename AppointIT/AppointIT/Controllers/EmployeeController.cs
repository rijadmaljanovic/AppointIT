using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Requests;
using Microsoft.AspNetCore.Authorization;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : CrudController<Employee, EmployeeSearchObject,EmployeeInsertRequest, EmployeeInsertRequest>
    {
        public EmployeeController(IEmployeeService _service) : base(_service) { }
    }
    
}
