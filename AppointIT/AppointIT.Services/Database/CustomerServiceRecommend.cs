using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace AppointIT.Services.Database
{
    public class CustomerServiceRecommend
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
