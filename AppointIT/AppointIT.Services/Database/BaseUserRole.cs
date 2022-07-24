using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace AppointIT.Services.Database
{
    public class BaseUserRole
    {
        public int Id { get; set; }
        public int BaseUserId { get; set; }
        public BaseUser BaseUser { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
