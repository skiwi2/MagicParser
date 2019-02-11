using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class WhenRule : RegexRule
    {
        public WhenRule() : base(@"^When (.+?)\, (.+)\.$", 2)
        {

        }

        public override uint Priority()
        {
            return 3;
        }
    }
}
