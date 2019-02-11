using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class WithRule : RegexRule
    {
        public WithRule() : base(@"^(.+?) with (.+)$", 2)
        {

        }
    }
}
