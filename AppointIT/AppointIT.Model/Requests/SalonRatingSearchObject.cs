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
        public DateTime RatingDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public int SalonId { get; set; }
        public virtual Salon Salon { get; set; } = null!;
    }
}
