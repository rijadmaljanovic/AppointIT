
using AppointIT.Services.Database;
using AppointIT.Services.Interfaces;
using AppointIT.Model.Requests;
using AppointIT.Model;
using Microsoft.AspNetCore.Authorization;

namespace AppointIT.Controllers
{
    [Authorize]
    public class TermController : CrudController<Model.Term, TermSearchObject, TermInsertRequest, TermInsertRequest>
    {
        public TermController(ITermService service) : base(service) { }
    }
}

