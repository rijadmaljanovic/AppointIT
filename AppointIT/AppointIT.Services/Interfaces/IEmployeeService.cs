using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model;

namespace AppointIT.Services.Interfaces
{
    public interface IEmployeeService:ICrudService<Model.Employee, EmployeeSearchObject, Model.Requests.EmployeeInsertRequest, Model.Requests.EmployeeInsertRequest>
    {
    }
}
