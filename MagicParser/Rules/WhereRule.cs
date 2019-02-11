using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class WhereRule : RegexRule
    {
        public WhereRule() : base(@"^(.+?), where (.+)$", 2)
        {

        }

        public override uint Priority()
        {
            return 3;
        }
    }
}
