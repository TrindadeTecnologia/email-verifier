using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier.Rules
{
    public class EmailValidatorServiceRule : IEmailRule
    {
        private string url = "http://api.emailvalidator.co";

        public string AccessKey { get; private set; }
        public EmailValidatorServiceRule(string accessKey = "")
        {
            if (!string.IsNullOrEmpty(accessKey)) AccessKey = accessKey;
        }

        public bool IsValid(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsValidAsync(string email)
        {
            HttpResponseMessage response = await Constants.HttpClient.GetAsync(url + $"?AccessKey={ AccessKey }&EmailAddress={ email }&VerificationLevel=4");

            if (response.IsSuccessStatusCode)
            {
                EmailValidatorResponse mailBoxResponse = await JsonConvert.DeserializeObjectAsync<EmailValidatorResponse>(await response.Content.ReadAsStringAsync());
                return mailBoxResponse.IsValid == "1";
            }

            return false;
        }

        public void SetAccessKey(string accessKey)
        {
            AccessKey = accessKey;
        }
    }
}
