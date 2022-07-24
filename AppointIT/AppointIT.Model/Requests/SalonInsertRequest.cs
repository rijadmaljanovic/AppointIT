﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Requests
{
    public class SalonInsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte[] Photo { get; set; }
        public string Location { get; set; }
        public int CityId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
