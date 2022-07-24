using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppointIT.Services.Interfaces;

namespace AppointIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CityController : BaseReadController<Model.City, object>
    {
        public CityController(ICityService service) : base(service) { }
    }
}
