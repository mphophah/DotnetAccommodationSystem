using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class PropertyVM
    {
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
        public IEnumerable<SelectListItem> ParkingList { get; set; }
        public IEnumerable<SelectListItem> PropertyTypeList { get; set; }
        public string DateCreated { get; set; }
    }

    public class EditPropertyVM
    {
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
        public string DateCreated { get; set; }
    }



}
