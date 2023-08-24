using AMS.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AMS.Data
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Amount { get; set; }

        [ForeignKey("StuffId")]
        public Stuff Stuff { get; set; }
        public int StuffId { get; set; }
        public string isPaid { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
