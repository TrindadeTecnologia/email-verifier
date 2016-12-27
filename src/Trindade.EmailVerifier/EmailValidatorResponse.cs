using Newtonsoft.Json;

namespace Trindade.EmailVerifier
{
    internal class EmailValidatorResponse
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("StatusMsg")]
        public string StatusMsg { get; set; }
        [JsonProperty("IsValid")]
        public string IsValid { get; set; }
        [JsonProperty("Reason")]
        public string Reason { get; set; }
    }
}
