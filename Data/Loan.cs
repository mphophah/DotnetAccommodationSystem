using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        public int LoanTerm { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string RemainingAmount { get; set; }
        public string LoanNumber { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string isDeleted { get; set; }

        [ForeignKey("LoanTypeId")]
        public LoanType LoanType { get; set; }
        public int LoanTypeId { get; set; }
        public string Status { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }

}
