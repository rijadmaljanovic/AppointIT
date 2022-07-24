using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Requests;

namespace AppointIT.Services.Interfaces
{
    public interface IServiceService : ICrudService<Model.Service, Model.ServiceSearchObject, ServiceInsertRequest, ServiceInsertRequest>
    {
    }

}
