using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class UntilYourNextTurnRule : RegexRule
    {
        public UntilYourNextTurnRule() : base(@"^until your next turn, (.+)$", 1)
        {

        }

        public override int Priority()
        {
            return 3;
        }
    }
}
