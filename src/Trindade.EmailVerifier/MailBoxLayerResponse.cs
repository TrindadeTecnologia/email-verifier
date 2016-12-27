using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier
{
    internal class MailBoxLayerResponse
    {
        [JsonProperty("smtp_check")]
        public bool SmtpCheck { get; set; }

        [JsonProperty("free")]
        public bool Free { get; set; }

        [JsonProperty("mx_found")]
        public bool MxFound { get; set; }
    }
}
