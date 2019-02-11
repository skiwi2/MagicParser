using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class KeywordAbilityRule : RegexRule
    {
        public KeywordAbilityRule() : base(new string[] { @"^(Addendum) — (?:.+), (.+)\.$", @"^(Scry) (\d+)$" }, 2)
        {

        }

        public override int Priority()
        {
            return 3;
        }
    }
}
