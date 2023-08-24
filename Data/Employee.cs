using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Data
{
    public class Employee : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public string isDeleted { get; set; }
        public string IntrestingKey { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
