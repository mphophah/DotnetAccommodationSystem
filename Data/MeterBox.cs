using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AMS.Data
{
    public class MeterBox
    {
        [Key]
        public int Id { get; set; }
        public string MeterBoxNumber { get; set; }
        public string Description { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey("MeterBoxTypeId")]
        public MeterBoxType MeterBoxType { get; set; }
        public int MeterBoxTypeId { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
