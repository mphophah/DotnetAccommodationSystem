using System.ComponentModel.DataAnnotations;

namespace AMS.Data
{
    public class Admission
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
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }

    }
}
