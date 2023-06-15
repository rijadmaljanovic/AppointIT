using AppointIT.Model.Models;
using AppointIT.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointIT.Services.Interfaces
{
    public interface IServiceRatingService : ICrudService<ServiceRating, ServiceRatingSearchObject, ServiceRatingInsertRequest, ServiceRatingInsertRequest>
    {
        int GetLastService();
    }
}
