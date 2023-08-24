using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class ManagePropertyVM
    {
        public int Id { get; set; }
        public string available { get; set; }
        public string RentAmount { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey("RentTypeId")]
        public RentType RentType { get; set; }
        public int RentTypeId { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> PropertyList { get; set; }
        public IEnumerable<SelectListItem> RentTypeList { get; set; }
        public string DateCreated { get; set; }
    }

    public class EditManagePropertyVM
    {
        public int Id { get; set; }
        public string available { get; set; }
        public string RentAmount { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey("RentTypeId")]
        public RentType RentType { get; set; }
        public int RentTypeId { get; set; }
        public string DateCreated { get; set; }
    }



}
