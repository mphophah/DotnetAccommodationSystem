using System.ComponentModel.DataAnnotations;
using System;
namespace AMS.Data
{
    public class SmsUsage
    {
        [Key]
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string SmsDate { get; set; }
        public string SmsResoan { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
