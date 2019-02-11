using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class AddendumRule : RegexRule
    {
        public AddendumRule() : base(@"^Addendum — If you cast this spell during your main phase, (.+).$", 1)
        {

        }

        public override uint Priority()
        {
            return 3;
        }

        public override bool IsLeafRule()
        {
            return false;
        }
    }
}
