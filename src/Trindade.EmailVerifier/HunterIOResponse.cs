using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier
{
    //    {
    //  "data": {
    //    "result": "risky",
    //    "score": 72,
    //    "email": "leonardo.trindade@ibta.edu.br",
    //    "regexp": true,
    //    "gibberish": false,
    //    "disposable": false,
    //    "webmail": false,
    //    "mx_records": true,
    //    "smtp_server": true,
    //    "smtp_check": true,
    //    "accept_all": true,
    //    "sources": []
    //},
    //  "meta": {
    //    "params": {
    //      "email": "leonardo.trindade@ibta.edu.br"
    //    }
    //  }
    //}

    public class HunterIOResponse
    {
        [JsonProperty("data")]
        public HunterIOData Data { get; set; }

        public class HunterIOData
        {
            [JsonProperty("smtp_check")]
            public bool SmtpCheck { get; set; }
        }
    }
}
