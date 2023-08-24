using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class LoanInstallment
    {
        [Key]
        public int Id { get; set; }
        public string Amount { get; set; }
        public string datePaid { get; set; }
        public string isDeleted { get; set; }
        [ForeignKey("LoanId")]
        public Loan Loan { get; set; }
        public int LoanId { get; set; }
        //public string Remaining { get; set; }
        //public string LoanNumber { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
