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
    [Authorize]
    public class CustomerController : CrudController<Customer, CustomerSearchObject, object, object>
    {
        public CustomerController(ICustomerService _service) : base(_service)
        {

        }
    }
}
