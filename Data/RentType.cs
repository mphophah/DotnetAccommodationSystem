using System.ComponentModel.DataAnnotations;
using System;
namespace AMS.Data
{
    public class RentType
    {
        [Key]
        public int Id { get; set; }
        public string RentTypeName { get; set; }
        public string Description { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
