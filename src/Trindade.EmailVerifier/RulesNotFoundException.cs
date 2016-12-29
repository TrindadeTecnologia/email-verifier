using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier
{
    public class RulesNotFoundException : Exception
    {
        public RulesNotFoundException() : base("The rules was not found.")
        {

        }
    }
}
