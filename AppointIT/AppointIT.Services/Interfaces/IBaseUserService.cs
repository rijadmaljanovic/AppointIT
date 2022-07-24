﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Requests;

namespace AppointIT.Services.Interfaces
{
    public interface IBaseUserService
    {
        Task<Model.BaseUser> Login(string username, string password);
        Model.BaseUser GetById(int id);
        Model.BaseUser Insert(BaseUserInsertRequest request);
        IEnumerable<Model.BaseUser> GetAll();
        Model.BaseUser Update(int Id, BaseUserInsertRequest request);
        Model.BaseUser Register(BaseUserInsertRequest request);

    }
}
