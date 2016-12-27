using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trindade.EmailVerifier.Rules;

namespace Trindade.EmailVerifier
{
    public static class DefaultRules
    {
        public static SintaxRule RegexRule = new SintaxRule();
        public static MxRule MxRule = new MxRule();
    }

    public sealed class EmailVerifier
    {
        private List<IEmailRule> rules = new List<IEmailRule>();

        public void AddRule(IEmailRule rule)
        {
            rules.Add(rule);
        }

        public void AddRule(object defaultRule)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(string email)
        {
            if (!rules.Any()) throw new RuleNotFoundException();

            bool result = rules.All(rule => rule.IsValid(email));

            return result;
        }

        public async Task<bool> IsValidAsync(string email)
        {
            if (!rules.Any()) throw new RuleNotFoundException();
            bool result = false;

            foreach (var rule in rules)
            {
                result = await rule.IsValidAsync(email);
                if (!result) break;
            }

            return result;
        }
    }
}
