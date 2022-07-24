using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model;
using AppointIT.Model.Requests;
using Microsoft.AspNetCore.Authorization;
using AppointIT.Services.Interfaces;


namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : CrudController<Model.Employee,EmployeeSearchObject,EmployeeInsertRequest, EmployeeInsertRequest>
    {
        public EmployeeController(IEmployeeService _service) : base(_service) { }
    }
    
}
