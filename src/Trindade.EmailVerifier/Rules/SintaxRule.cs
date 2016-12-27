using System;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier.Rules
{
    public class SintaxRule : IEmailRule
    {
        public bool IsValid(string email)
        {
            return Constants.EmailAddressValidator.IsValid(email);
        }

        public Task<bool> IsValidAsync(string email)
        {
            return Task.FromResult(Constants.EmailAddressValidator.IsValid(email));
        }
    }
}
