using System;
//using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
//using RestSharp.Authenticators;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace AMS
{
  public sealed class SmsPortalToken: ISmsPortalToken
	{
		private readonly IConfiguration _config;
		public SmsPortalToken(IConfiguration config)
		{
			_config = config;
		}

		public string ClientId { get { return _config["AppSettings:SmsClientId"]; } }
		public string ApiSecret { get { return _config["AppSettings:SmsApiSecret"]; } }

		public string Base64Secret
		{
			get
			{
				var secret = ClientId + ":" + ApiSecret;
				byte[] bytes = Encoding.UTF8.GetBytes(secret);
				return Convert.ToBase64String(bytes);

			}
		}

		public string Token { get; set; }
		public string Schema { get; set; }
		public int ExpiresInMinutes { get; set; }
		public async Task RefreshToken()
		{
			var url = _config["AppSettings:SmsPortalUrl"];
			var client = new RestClient(url); 
			client.Authenticator = new HttpBasicAuthenticator(ClientId, ApiSecret);

			var request = new RestRequest("v1/authentication", Method.GET);
			var model = await client.ExecuteAsync<TokenModel>(request);
			if (model != null && model.Data != null) SetToken(model.Data);
		}

		public void SetToken(TokenModel tm)
		{
			Token = tm.Token;
			Schema = tm.Schema;
			ExpiresInMinutes = tm.ExpiresInMinutes;
		}

		public async Task<string> SendSms(string smsBody, string number)
		{
			var url = _config["AppSettings:SmsPortalUrl"];
			var client = new RestClient(url);
			if(Token == null) await	RefreshToken();
			var authToken = Token;

			client.Authenticator = new JwtAuthenticator(authToken);
			var sendRequest = new RestSharp.RestRequest("v1/bulkmessages", Method.POST);
			sendRequest.AddJsonBody(new
			{
				Messages = new[]
				{
					new { Content = smsBody, Destination = number }
				}
			});
			var sendResponse = await client.ExecuteAsync(sendRequest);

			if (sendResponse.StatusCode == System.Net.HttpStatusCode.OK)
			{
				return sendResponse.Content;
			}
			else
			{
				return sendResponse.ErrorMessage;
			}
		}

		public async Task<string> SendBulkSms(List<SmsModel> models)
		{
			var url = _config["AppSettings:SmsPortalUrl"];
			var client = new RestClient(url);
			var authToken = Token;
			client.Authenticator = new JwtAuthenticator(authToken);
			var sendRequest = new RestSharp.RestRequest("v1/bulkmessages", Method.POST);

			var messages = new List<Message>();
			var smsList = models.Where(x => x.CellIsValid == true && x.Checked == true).ToList();
			foreach (var sms in smsList)
			{
				var message = new Message
				{
					Content = sms.Content,
					Destination = sms.Destination
				};
				messages.Add(message);
			}
			
			sendRequest.AddJsonBody(new { Messages = messages });

			var sendResponse = await client.ExecuteAsync(sendRequest);

			if (sendResponse.StatusCode == System.Net.HttpStatusCode.OK)
			{
				return sendResponse.Content;
			}
			else
			{
				return sendResponse.ErrorMessage;
			}

		}
  }


}

