using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Models;
using AppointIT.Model.Requests;

namespace AppointIT.Services.Interfaces
{
    public interface ICustomerService : ICrudService<Customer, CustomerSearchObject, object, object>
    {
    }
}
