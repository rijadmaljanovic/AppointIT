﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Requests
{
    public class EmployeeInsertRequest
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public byte[] Photo { get; set; }

    }
}
