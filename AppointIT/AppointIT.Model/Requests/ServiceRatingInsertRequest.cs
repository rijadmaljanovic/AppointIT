using AppointIT.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointIT.Model.Requests
{
    public class ServiceRatingInsertRequest
    {
        public int ServiceRatingId { get; set; }
        public double Rating { get; set; }
        public DateTime RatingDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
    }
}
