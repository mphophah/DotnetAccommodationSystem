using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AMS.Models
{
    public class LoanInstallmentVM
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string datePaid { get; set; }
        public string isDeleted { get; set; }
        // public string Remaining { get; set; }
        //public string LoanNumber { get; set; }
        public Loan Loan { get; set; }
        public int LoanId { get; set; }
        public IEnumerable<SelectListItem> LoanList { get; set; }
        public string DateCreated { get; set; }
    }
    public class EditLoanInstallmentVM
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string datePaid { get; set; }
        public string isDeleted { get; set; }
        public Loan Loan { get; set; }
        public int LoanId { get; set; }
        // public string Remaining { get; set; }
        //public string LoanNumber { get; set; }
        public string DateCreated { get; set; }

    }

}
