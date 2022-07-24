﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Requests
{
    public class TermInsertRequest
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? Reserved { get; set; }
        public DateTime? Date { get; set; }
        public int ServiceId { get; set; }
        //public Service Service { get; set; }
        public int? CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }
    }
}
