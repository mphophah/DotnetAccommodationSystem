using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class ParkingTypeVM
    {
        public int Id { get; set; }
        public string ParkingTypeName { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
    }

}
