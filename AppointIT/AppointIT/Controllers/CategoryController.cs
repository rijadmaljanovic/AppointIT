using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppointIT.Services.Interfaces;
using AppointIT.Model;

namespace AppointIT.Controllers
{
    [Authorize]
    public class CategoryController :CrudController<Model.Category,Model.Category,Model.Category,object>
    {
        public CategoryController(ICategoryService service) : base(service)
        {
        }
    }
}
