using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class WaterVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
public string DateCreated { get; set; }
    }

    
}
