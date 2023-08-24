using AMS.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AMS.Data
{
    public class ManageProperty
    {
        [Key]
        public int Id { get; set; }
        public string available { get; set; }
        public string RentAmount { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey("RentTypeId")]
        public RentType RentType { get; set; }
        public int RentTypeId { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
