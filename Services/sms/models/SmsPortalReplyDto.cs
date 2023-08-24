using System.ComponentModel.DataAnnotations;

namespace AMS
{
  public class SmsPortalDeliveryDto
  {
     
    public string Status { get; set; }

    public long EventId { get; set; }
    public int Mcc { get; set; } 
    public int MsgCount { get; set; }
    public string Mnc { get; set; }
    public string Msisdn { get; set; }

    public string UserReference { get; set; }

    public long Received { get; set; }

  }

  public class SmsPortalReplyDto
  {

    public string To { get; set; }

    public long Id { get; set; }

    public string Message { get; set; }

    public string Msisdn { get; set; }

    public long Received { get; set; }

    public string UserReference { get; set; }

  }
}