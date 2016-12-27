using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier.Services
{
    public class MailboxLayerServiceRule : IEmailRule
    {
        private string url = "http://apilayer.net/api/check";
 
        public string AccessKey { get; private set; }

        public MailboxLayerServiceRule(string accessKey = "")
        {
            if (!string.IsNullOrEmpty(accessKey)) AccessKey = accessKey;
        }

        public bool IsValid(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsValidAsync(string email)
        {
            HttpResponseMessage response = await Constants.HttpClient.GetAsync(url + $"?&access_key={ AccessKey }&email={ email }&smtp=1&format=1");

            if (response.IsSuccessStatusCode)
            {
                MailBoxLayerResponse mailBoxResponse = await JsonConvert.DeserializeObjectAsync<MailBoxLayerResponse>(await response.Content.ReadAsStringAsync());
                return mailBoxResponse.SmtpCheck;
            }

            return false;
        }

        public void SetAccessKey(string accessKey)
        {
            AccessKey = accessKey;
        }
    }
}
