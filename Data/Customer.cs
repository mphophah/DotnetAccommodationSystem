using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Data
{

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string MoveInNumber { get; set; }
        public string MoveInDate { get; set; }
        public string AccommodationIntrested { get; set; }
        public string process { get; set; }
        public string isDeleted { get; set; }
        public string TenantAccess { get; set; }
        // public byte[] FileContent { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
