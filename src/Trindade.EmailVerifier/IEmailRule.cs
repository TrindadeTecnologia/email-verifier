namespace Trindade.EmailVerifier
{
    public interface IEmailRule
    {
        bool IsValid(string email);
    }
}
