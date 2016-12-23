namespace Trindade.EmailVerifier.Rules
{
    public class SintaxRule : IEmailRule
    {
        public bool IsValid(string email)
        {
            return Constants.EmailAddressValidator.IsValid(email);
        }
    }
}
