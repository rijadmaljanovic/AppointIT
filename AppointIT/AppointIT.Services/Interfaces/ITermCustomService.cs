using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model;
using static AppointIT.Services.TermCustomService;

namespace AppointIT.Services.Interfaces
{
    public interface ITermCustomService
    {
        List<SalonCustom> GetAll(TermCustomSearchObject search = null);
    }
}
