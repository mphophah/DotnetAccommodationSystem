using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class InvoiceVM
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string isPaid { get; set; }
        public string Amount { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("RentTypeId")]
        public RentType RentType { get; set; }
        public int RentTypeId { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> RentTypeList { get; set; }
        public string DateCreated { get; set; }

    }

    public class EditInvoiceVM
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string isPaid { get; set; }
        public string Amount { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("RentTypeId")]
        public RentType RentType { get; set; }
        public int RentTypeId { get; set; }
        public string DateCreated { get; set; }
    }


}
