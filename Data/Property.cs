using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AMS.Data
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string Occupied { get; set; }
        public string OccupiedDate { get; set; }

        [ForeignKey("ParkingId")]
        public Parking Parking { get; set; }
        public int ParkingId { get; set; }

        [ForeignKey("PropertyTypeId")]
        public PropertyType PropertyType { get; set; }
        public int PropertyTypeId { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
