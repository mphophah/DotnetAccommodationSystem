using System;
using System.ComponentModel.DataAnnotations;
using AMS.Data;

namespace AMS.Models
{
    public class EmegencyVM
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Solved {get; set;}
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Property Property { get; set; }
        public int PropertyId  { get; set; }
        public string DateCreated { get; set; }

    }

    
}
