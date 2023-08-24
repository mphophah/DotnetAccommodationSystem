using System;
using System.Collections.Generic;

namespace AMS
{
  public partial class SmsQueueDto
  {
    public long Id { get; set; }
    public string ProcessCode { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateLastUpdated { get; set; }
    public string RequestJsonData { get; set; }
    public string Status { get; set; }
    public string ResponseJsonData { get; set; }
    public long? EventId { get; set; }
    public long AppointmentId { get; set; }
    public string AccountNo { get; set; }
    public int? UserId { get; set; }
  }

}