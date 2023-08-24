using System.Collections.Generic;

namespace AMS
{
  public class SmsDuplicatedResponse
  {
    public SmsPortalResponse ResponseObject { get; set; }
    public string ResponseString { get; set; }
    public string RequestString { get; set; }
  }
  public class SmsPortalResponse
  {
    public double Cost { get; set; }
    public double RemainingBalance { get; set; }
    public long EventId { get; set; }
    public int Messages { get; set; }
    public int Parts { get; set; }
    public string Sample { get; set; }
    public Errors ErrorReport { get; set; }

    public List<BreakDown> CostBreakdown { get; set; }
  }

  public class BreakDown
  {
    public int Quantity { get; set; }
    public double Cost { get; set; }
    public string Network { get; set; }
  }

  public class Errors
  {
    public int NoNetwork { get; set; }
    public int Duplicates { get; set; }
    public int OptedOuts { get; set; }
    //  "faults": []
  }
}