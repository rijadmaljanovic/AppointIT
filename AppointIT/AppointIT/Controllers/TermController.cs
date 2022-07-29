
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;
using Microsoft.AspNetCore.Authorization;
using AppointIT.Model.Models;

namespace AppointIT.Controllers
{
    [Authorize]
    public class TermController : CrudController<Model.Models.Term, TermSearchObject, TermInsertRequest, TermInsertRequest>
    {
        public TermController(ITermService service) : base(service) { }
    }
}

