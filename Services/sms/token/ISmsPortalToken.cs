using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS
{
	public interface ISmsPortalToken
	{
		Task RefreshToken();
    void SetToken(TokenModel model);
    Task<string> SendSms(string smsBody, string number);
		Task<string> SendBulkSms(List<SmsModel> models);
        
    }
}
