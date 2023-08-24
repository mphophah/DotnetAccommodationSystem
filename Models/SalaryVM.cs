using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class SalaryVM
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string isPaid { get; set; }
        public string Amount { get; set; }
        [ForeignKey("StuffId")]
        public Stuff Stuff { get; set; }
        public int StuffId { get; set; }
        public IEnumerable<SelectListItem> StuffList { get; set; }
        public string DateCreated { get; set; }

    }

    public class EditSalaryVM
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string isPaid { get; set; }
        public string Amount { get; set; }
        [ForeignKey("StuffId")]
        public Stuff Stuff { get; set; }
        public int StuffId { get; set; }
        public string DateCreated { get; set; }
    }


}
