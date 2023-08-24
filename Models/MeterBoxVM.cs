using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class MeterBoxVM
    {
        public int Id { get; set; }
        public string MeterBoxNumber { get; set; }
        public string Description { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey("MeterBoxTypeId")]
        public MeterBoxType MeterBoxType { get; set; }
        public int MeterBoxTypeId { get; set; }
        public IEnumerable<SelectListItem> PropertyList { get; set; }
        public IEnumerable<SelectListItem> MeterBoxTypeList { get; set; }
        public string DateCreated { get; set; }
    }

    public class EditMeterBoxVM
    {
        public int Id { get; set; }
        public string MeterBoxNumber { get; set; }
        public string Description { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey("MeterBoxTypeId")]
        public MeterBoxType MeterBoxType { get; set; }
        public int MeterBoxTypeId { get; set; }
        public string DateCreated { get; set; }
    }



}
