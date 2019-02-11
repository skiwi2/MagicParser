using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class UnlessRule : RegexRule
    {
        public UnlessRule() : base(@"^(.+?) unless (.+)$", 2)
        {

        }

        public override int Priority()
        {
            return 2;
        }
    }
}
