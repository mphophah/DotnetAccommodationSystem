using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AMS.Data
{
    public class Emegency
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Solved { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
