using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Models
{
    public class SalonServices
    {
        public int SalonServicesId { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
