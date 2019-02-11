using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class MultilineRule : SplitRule
    {
        public MultilineRule() : base(@"\n")
        {

        }

        public override int Priority()
        {
            return 5;
        }
    }
}
