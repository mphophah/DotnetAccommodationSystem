using System;
using System.Collections.Generic;

namespace AMS
{
  public partial class SmsReplyDto
  {
		public long Id { get; set; }
		public string ProcessCode { get; set; }
		public string To { get; set; }
		public string Message { get; set; }
		public string Msisdn { get; set; }
		public DateTime DateCreated { get; set; }
		public string JsonData { get; set; }
		public long EventId { get; set; }
	}

}