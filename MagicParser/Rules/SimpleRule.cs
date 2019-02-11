using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class SimpleRule : RegexRule
    {
        public SimpleRule() : base(@"^(.+)\.$", 1)
        {

        }

        public override uint Priority()
        {
            return 2;
        }

        public override bool IsLeafRule()
        {
            return false;
        }
    }
}
