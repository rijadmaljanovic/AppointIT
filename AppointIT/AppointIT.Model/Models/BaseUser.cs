﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppointIT.Model.Models
{
    public class BaseUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? isActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<BaseUserRole> BaseUserRoles { get; set; }
        public string FirstAndLastName
        {
            get { return $"{FirstName} {LastName}"; }
        }

    }
}
