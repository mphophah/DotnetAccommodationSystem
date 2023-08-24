using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class CleaningVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string dateCleaning { get; set; }
        public string Status { get; set; }
        [ForeignKey("MaintenanceTypeId")]
        public MaintenanceType MaintenanceType { get; set; }
        public int MaintenanceTypeId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> PropertyList { get; set; }
        public string DateCreated { get; set; }

    }

    public class EditCleaningVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string dateCleaning { get; set; }
        public string Status { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public string DateCreated { get; set; }
    }

}
