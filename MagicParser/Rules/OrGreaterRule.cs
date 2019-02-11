using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class OrGreaterRule : RegexRule
    {
        public OrGreaterRule() : base(@"^(\d+) or greater$", 1)
        {

        }

        public override int Priority()
        {
            return 0;
        }
    }
}
