using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class NumberOfRule : RegexRule
    {
        public NumberOfRule() : base(@"^the number of (.+?)s$", 1)
        {

        }
    }
}
