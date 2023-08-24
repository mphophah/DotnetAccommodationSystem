using System.ComponentModel.DataAnnotations;
using System;
namespace AMS.Data
{
    public class Audit
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public string Action { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
