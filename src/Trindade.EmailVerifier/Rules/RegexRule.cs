namespace Trindade.EmailVerifier.Rules
{
    public class RegexRule : IEmailRule
    {
        public bool IsValid(string email)
        {
            return Constants.EmailAddressValidator.IsValid(email);
        }
    }
}
