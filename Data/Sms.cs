using System.ComponentModel.DataAnnotations;
using System;
namespace AMS.Data
{
    public class Sms
    {
        [Key]
        public int Id { get; set; }
        public string CommunicationType { get; set; }
        public string EmailReceiver { get; set; }
        public string EmailSubject { get; set; }
        public string EmailMessage { get; set; }
        public string SmsReceiver { get; set; }
        public string SmsSubject { get; set; }
        public string SmsMessage { get; set; }
        public string Process { get; set; }
        public string Respond { get; set; }
        public string TenantId { get; set; }
        public string isDeleted { get; set; }
        public string DateCreated { get; set; }
        public string DateDeleted { get; set; }
    }
}
