using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class LifeTotalBecomesRule : RegexRule
    {
        public LifeTotalBecomesRule() : base(@"^Your life total becomes (\d+)$", 1)
        {

        }

        public override bool IsLeafRule()
        {
            return false;
        }
    }
}
