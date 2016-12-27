using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier.Rules
{
    public class RegexRule : IEmailRule
    {
        public string Regex { get; private set; }

        public RegexRule(string regex)
        {
            Regex = regex;
        }

        public bool IsValid(string email)
        {
            return new Regex(Regex).IsMatch(email);
        }

        public Task<bool> IsValidAsync(string email)
        {
            return Task.FromResult<bool>(new Regex(Regex).IsMatch(email));
        }
    }
}
