﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model
{
    public class TermSearchObject
    {
        public int SalonId { get; set; }
        public int? CustomerId { get; set; }
        public int? ServiceId { get; set; }
        public bool IsReport { get; set; }
        public string[] IncludeList { get; set; }
        public DateTime? Date { get; set; }
    }
}
