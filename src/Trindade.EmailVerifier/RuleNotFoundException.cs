using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier
{
    public class RuleNotFoundException : Exception
    {
        public RuleNotFoundException() : base("Rules not found.")
        {

        }
    }
}
