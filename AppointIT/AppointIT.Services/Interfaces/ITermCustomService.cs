﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointIT.Model.Models;
using AppointIT.Services.Database;
using AutoMapper;

namespace AppointIT.Services.Interfaces
{
    public interface ITermCustomService
    {
        Model.Models.TermCustom Get(int id);
    }
}
