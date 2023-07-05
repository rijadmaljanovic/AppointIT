using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Models;
using AppointIT.Model.Requests;
using static AppointIT.Services.SalonService;

namespace AppointIT.Services.Interfaces
{
    public interface ISalonService:ICrudService<Salon, SalonSearchObject, SalonInsertRequest, SalonInsertRequest>
    {
        List<SalonCustom> SearchFilter(TermCustomSearchObject search = null);

    }
}
