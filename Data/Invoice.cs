using AMS.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AMS.Data
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Amount { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("RentTypeId")]
        public RentType RentType { get; set; }
        public int RentTypeId { get; set; }
        public string isPaid { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
