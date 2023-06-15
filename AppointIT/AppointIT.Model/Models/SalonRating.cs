using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointIT.Model.Models
{
    public class SalonRating
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
