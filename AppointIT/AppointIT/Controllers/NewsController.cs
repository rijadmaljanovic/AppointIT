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
    [Authorize]

    public class NewsController : CrudController<News, NewsSearchObject, NewsInsertRequest, NewsInsertRequest>
    {
        public NewsController(INewsService _service) : base(_service)
        {

        }

    }
}
