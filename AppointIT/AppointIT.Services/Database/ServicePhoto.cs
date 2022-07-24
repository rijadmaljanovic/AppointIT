using System;
using System.Collections.Generic;

#nullable disable

namespace AppointIT.Services.Database
{
    public partial class ServicePhoto
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public int  ServiceId { get; set; }
        public  Service Service { get; set; }

    }
}
