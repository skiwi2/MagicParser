using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class AbilityRule : RegexRule
    {
        public AbilityRule() : base(@"^(.+): (.+)\.$", 2)
        {

        }

        public override uint Priority()
        {
            return 3;
        }
    }
}
