using AMS.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class StuffVM
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Occupation/Job")]
        public string Occupation { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Display(Name = "Salary")]
        public string Salary { get; set; }

        [Display(Name = "Number Of People Move In")]
        public string MoveInNumber { get; set; }
        [Display(Name = "Move In Date")]
        public string MoveInDate { get; set; }
        [Display(Name = "Accommodation Intrested")]
        public string AccommodationIntrested { get; set; }
        [Display(Name = "process")]
        public string process { get; set; }
        public string Password { get; set; }
        public string TenantAccess { get; set; }
        public string isDeleted { get; set; }
        public byte[] FileContent { get; set; }
        public string DateCreated { get; set; }
    }

}
