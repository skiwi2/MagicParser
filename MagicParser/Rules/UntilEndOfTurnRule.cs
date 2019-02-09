using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class UntilEndOfTurnRule : RegexRule
    {
        public UntilEndOfTurnRule() : base(@"^until end of turn\, (.+)$", 1)
        {

        }

        public override bool IsLeafRule()
        {
            return false;
        }
    }
}
