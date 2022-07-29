﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppointIT.Model.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Duration { get; set; }
        public byte[] Photo { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string ServiceForCombo
        {
            get { return $"{Name} -  {Price} KM - {Duration} min"; }
        }

    }
}
