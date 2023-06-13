using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointIT.Model.Models
{
    public class ServiceRating
    {
        public int ServiceRatingId { get; set; }
        public double Rating { get; set; }
        public DateTime RatingDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; } = null!;
    }
}
