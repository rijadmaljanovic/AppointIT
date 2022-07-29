﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Models
{
    public class TermCustomSearchObject
    {
        public string Location { get; set; }
        public string ServiceName { get; set; }
        public DateTime? Date { get; set; }
        public int? CustomerId { get; set; }

    }
}
