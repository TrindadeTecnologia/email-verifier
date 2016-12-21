using ARSoft.Tools.Net.Dns;
using System.ComponentModel.DataAnnotations;

namespace Trindade.EmailVerifier
{
    public class Constants
    {
        public static EmailAddressAttribute EmailAddressValidator = new EmailAddressAttribute();
        public static IDnsResolver DnsResolver = new DnsStubResolver();
    }
}
