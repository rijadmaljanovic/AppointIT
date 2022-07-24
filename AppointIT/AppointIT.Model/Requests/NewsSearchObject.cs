using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Requests
{
    public class NewsSearchObject
    {
        public string[] IncludeList{ get; set; }
        public int SalonId { get; set; }
    }
}
