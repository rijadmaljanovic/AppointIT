using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;

namespace AppointIT.Services
{
    public class CategoryService : CrudService<Model.Models.Category, Database.Category, Model.Models.Category,Model.Models.Category,object>, ICategoryService
    {
        public CategoryService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
