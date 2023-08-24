using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class ParkingVM
    {
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
        public IEnumerable<SelectListItem> ParkingTypeList { get; set; }
        public string DateCreated { get; set; }

    }

    public class EditParkingVM
    {
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
    }


}
