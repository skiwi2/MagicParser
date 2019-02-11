using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class WheneverRule : RegexRule
    {
        public WheneverRule() : base(@"^Whenever (.+?)\, (.+)\.$", 2)
        {

        }

        public override uint Priority()
        {
            return 3;
        }
    }
}
