using System.ComponentModel.DataAnnotations;
using System;
namespace AMS.Data
{
    public class DocumentM
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public byte[] FileData { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}

