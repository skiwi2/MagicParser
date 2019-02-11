using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class OrRule : RegexRule
    {
        public OrRule() : base(@"^(.+?) or (.+)$", 2)
        {

        }

        public override int Priority()
        {
            return 0;
        }
    }
}
