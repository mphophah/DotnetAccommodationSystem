using AMS.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AMS.Data
{
    public class Maintenance
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        [ForeignKey("MaintenanceTypeId")]
        public MaintenanceType MaintenanceType { get; set; }
        public int MaintenanceTypeId { get; set; }
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
