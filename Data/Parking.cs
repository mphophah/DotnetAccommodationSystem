using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class Parking
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string isDeleted { get; set; }
        public string isAvailable { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }
        [ForeignKey("ParkingTypeId")]
        public ParkingType ParkingType { get; set; }
        public int ParkingTypeId { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
