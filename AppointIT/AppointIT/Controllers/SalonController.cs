using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;

namespace AppointIT.Controllers
{
    [Authorize]
    public class SalonController : CrudController<Model.Salon, Model.SalonSearchObject, SalonInsertRequest, SalonInsertRequest>
    {
        public SalonController(ISalonService _service) : base(_service) { }
    }
}
