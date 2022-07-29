using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Models;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CityController : BaseReadController<City, object>
    {
        public CityController(ICityService service) : base(service) { }
    }
}
