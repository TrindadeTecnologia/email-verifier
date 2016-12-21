using System;
using System.Collections.Generic;
using System.Linq;

namespace Trindade.EmailVerifier
{
    public static class DefaultRules
    {
        public static RegexRule RegexRule = new RegexRule();
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
            if (!rules.Any())
                throw new Exception("None rules found");

            bool result = rules.All(rule => rule.IsValid(email));

            return result;
        }
    }
}
