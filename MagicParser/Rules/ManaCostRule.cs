using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class ManaCostRule : RegexRule
    {
        public ManaCostRule() : base(@"^(\{.+\})$", 1)
        {

        }

        public override bool IsLeafRule()
        {
            return true;
        }
    }
}
