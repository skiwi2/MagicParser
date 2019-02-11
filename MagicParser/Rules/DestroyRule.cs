using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class DestroyRule : RegexRule
    {
        public DestroyRule() : base(@"^Destroy (.+).$", 1)
        {

        }

        public override int Priority()
        {
            return 4;
        }
    }
}
