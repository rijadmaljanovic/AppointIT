using AppointIT.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointIT.Model.Requests
{
    public class SalonRatingSearchObject
    {
        public int SalonRatingId { get; set; }
        public double Rating { get; set; }
        public int CustomerId { get; set; }
        public int SalonId { get; set; }
    }
}
