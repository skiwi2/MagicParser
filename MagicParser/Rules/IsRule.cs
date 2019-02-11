using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class IsRule : RegexRule
    {
        public IsRule() : base(@"^(.+?) is (.+)$", 2)
        {

        }

        public override int Priority()
        {
            return 2;
        }
    }
}
