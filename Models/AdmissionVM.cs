using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class AdmissionVM
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public string MoveInNumber { get; set; }
        public string MoveInDate { get; set; }
        public string AccommodationIntrested { get; set; }
        public string status { get; set; }
        public string DateCreated { get; set; }

    }


}
