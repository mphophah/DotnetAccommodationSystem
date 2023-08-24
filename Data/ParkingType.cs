using System.ComponentModel.DataAnnotations;
using System;
namespace AMS.Data
{
    public class ParkingType
    {
        [Key]
        public int Id { get; set; }
        public string ParkingTypeName { get; set; }
        public string Description { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
