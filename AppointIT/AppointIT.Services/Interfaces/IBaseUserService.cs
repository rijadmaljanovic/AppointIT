using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Models;
using AppointIT.Model.Requests;

namespace AppointIT.Services.Interfaces
{
    public interface IBaseUserService
    {
        Task<BaseUser> Login(string username, string password);
        BaseUser GetById(int id);
        BaseUser Insert(BaseUserInsertRequest request);
        IEnumerable<BaseUser> GetAll();
        BaseUser Update(int Id, BaseUserInsertRequest request);
        BaseUser Register(BaseUserInsertRequest request);

    }
}
