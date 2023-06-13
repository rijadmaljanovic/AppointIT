using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointIT.Services.Database
{
    public class ServiceRating
    {
        [Key]
        public int ServiceRatingId { get; set; }
        public double Rating { get; set; }
        public DateTime RatingDate { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; } = null!;

    }
}
