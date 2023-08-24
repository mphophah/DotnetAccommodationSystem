using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class SmsUsageVM
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string SmsDate {get; set;}
        public string SmsResoan {get; set;}
        public string DateCreated { get; set; }
    }
}
      
      
      
