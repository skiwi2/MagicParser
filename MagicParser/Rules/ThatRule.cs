using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class ThatRule : RegexRule
    {
        public ThatRule() : base(@"^that (.+)$", 1)
        {

        }

        public override bool IsLeafRule()
        {
            return false;
        }
    }
}
