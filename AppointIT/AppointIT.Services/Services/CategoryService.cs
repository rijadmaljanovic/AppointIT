using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;

namespace AppointIT.Services
{
    public class CategoryService : CrudService<Model.Category, Database.Category, Model.Category,Model.Category,object>, ICategoryService
    {
        public CategoryService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
