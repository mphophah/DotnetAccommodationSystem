using System;
using System.Collections.Generic;
namespace AMS
{
	// public class SmsModel
	// {
	//   public long AccountId { get; set; }
	//   public string AccountNo { get; set; }
	//   public string FullName { get; set; }
	//   public string Content { get; set; }
	//   public string Destination { get; set; }
	//   public bool CellIsValid { get; set; }
	//   public bool Checked { get; set; }
	//   public string JsonData { get; set; }
	// }
  public class SmsModel
	{
		/*public SmsModel(string FullName, string Content, string Destination, bool CellIsValid, bool Checked)
		{
			this.FullName = FullName;
			this.Content = Content;
			this.Destination = Destination;
			this.CellIsValid = CellIsValid;
			this.Checked = Checked;
		}*/
		//public long AccountId { get; set; }
		//public string AccountNo { get; set; }
        public string FullName { get; set; }
		public string Content { get; set; }
		public string Destination { get; set; }
		public bool CellIsValid { get; set; }
		public bool Checked { get; set; }
		//public string JsonData { get; set; }
	}

	public class BulkSmsModel
	{
		public string CustomerCode { get; set; }
		public string ProcessCode { get; set; }
		public int UserId { get; set; }

		public List<SmsModel> SmsList { get; set; }
	}

  public class TokenModel
  {
    public string Token { get; set; }
    public string Schema { get; set; }
    public int ExpiresInMinutes { get; set; }
  }

  public class Message
  {
    public string Content { get; set; }
    public string Destination { get; set; }
  }

}