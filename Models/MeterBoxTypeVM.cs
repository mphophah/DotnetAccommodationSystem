using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class MeterBoxTypeVM
    {
        public int Id { get; set; }
        public string MeterBoxName { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
    }

}
