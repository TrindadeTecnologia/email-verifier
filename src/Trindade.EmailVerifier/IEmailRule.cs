using System.Threading.Tasks;

namespace Trindade.EmailVerifier
{
    public interface IEmailRule
    {
        bool IsValid(string email);

        Task<bool> IsValidAsync(string email);
    }
}
