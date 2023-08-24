using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class ElectricityVM
    {
        public int Id { get; set; }
        public string Units { get; set; }
        public string Amount { get; set; }
        public string PurchaseDate { get; set; }
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

    public class EditElectricityVM
    {
        public int Id { get; set; }
        public string Units { get; set; }
        public string Amount { get; set; }
        public string PurchaseDate { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public string DateCreated { get; set; }
    }


}
