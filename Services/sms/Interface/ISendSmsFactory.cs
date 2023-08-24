using System.Threading.Tasks;

namespace AMS
{
  public interface ISendSmsFactory
  {
    Task<SmsDuplicatedResponse> SendSingleSMS(string cellNo, string sms);
    Task<SmsDuplicatedResponse> SendBulkSMS(BulkSmsModel model);
    Task<bool> ValidateCellNo(string n);

    Task<BulkSmsModel> CheckValidCellNo(BulkSmsModel model);
    Task<SmsQueueDto> QueueSMS(SmsQueueDto dto, string cellNo);
    //Task<bool> QueueAndSendProcessSMS(Appointment appointment, string processCode);
    //Task<bool> QueueAndSendProcessSMS(AppointmentGeneralSms appointment, string processCode);
  }
}