﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model;
using AppointIT.Model.Requests;

namespace AppointIT.Services.Interfaces
{
    public interface ISalonService:ICrudService<Model.Salon, SalonSearchObject, SalonInsertRequest, SalonInsertRequest>
    {
    }
}