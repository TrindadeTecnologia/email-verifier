using ARSoft.Tools.Net.Dns;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace Trindade.EmailVerifier
{
    public class Constants
    {
        public static EmailAddressAttribute EmailAddressValidator = new EmailAddressAttribute();
        public static IDnsResolver DnsResolver = new DnsStubResolver();
        public static HttpClient HttpClient = new HttpClient();
    }
}
