using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointIT.Services.Database
{
    public class SalonRating
    {
        [Key]
        public int SalonRatingId { get; set; }
        public double Rating { get; set; }
        public DateTime RatingDate { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(Salon))]
        public int SalonId { get; set; }
        public virtual Salon Salon { get; set; } = null!;

    }
}
