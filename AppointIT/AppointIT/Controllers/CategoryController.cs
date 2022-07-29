using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;

namespace AppointIT.Controllers
{
    [Authorize]
    public class CategoryController :CrudController<Category,Category,Category,object>
    {
        public CategoryController(ICategoryService service) : base(service)
        {
        }
    }
}
