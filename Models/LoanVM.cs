using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class LoanVM
    {
        public int Id { get; set; }

        [Display(Name = "Loan Term")]
        [Required]
        public int LoanTerm { get; set; }
        [Display(Name = "Amount")]
        [Required]
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string RemainingAmount { get; set; }
        public string LoanNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }

        public int LoanTypeId { get; set; }
        public LoanType LoanType { get; set; }
        public IEnumerable<SelectListItem> LoanTypeList { get; set; }
        public string Status { get; set; }
        public string DateCreated { get; set; }
    }

    public class EditLoanVM
    {
        public int Id { get; set; }
        [Display(Name = "Loan Term")]
        [Required]
        public int LoanTerm { get; set; }

        [Display(Name = "Amount")]
        [Required]
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int LoanTypeId { get; set; }
        public LoanType LoanType { get; set; }
        public string Status { get; set; }
        public string LoanNumber { get; set; }
        public string RemainingAmount { get; set; }
        public string DateCreated { get; set; }
    }

}
