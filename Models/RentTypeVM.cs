using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class RentTypeVM
    {
        public int Id { get; set; }
        public string RentTypeName { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }

    }

}
