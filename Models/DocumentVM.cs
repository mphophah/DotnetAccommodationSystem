using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class DocumentVM
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
    }
}
