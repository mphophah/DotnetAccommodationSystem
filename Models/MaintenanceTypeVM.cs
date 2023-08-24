using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class MaintenanceTypeVM
    {
        public int Id { get; set; }
        public string MaintenanceTypeName { get; set; }
        public string Description { get; set; }
public string DateCreated { get; set; }
    }
    
}
