﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Models
{
    public class CustomerSearchObject
    {

        public int SalonId { get; set; }
        public bool ReportData { get; set; }
        public string[] IncludeList { get; set; }
        public string Email { get; set; }
    }
}
