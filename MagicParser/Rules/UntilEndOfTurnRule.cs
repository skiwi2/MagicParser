using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class UntilEndOfTurnRule : RegexRule
    {
        public UntilEndOfTurnRule() : base(new string[] { @"^until end of turn\, (.+)$", @"^(.+?) until end of turn$" }, 1)
        {

        }

        public override int Priority()
        {
            return 3;
        }
    }
}
