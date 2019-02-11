using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class AttacksAloneRule : RegexRule
    {
        public AttacksAloneRule() : base(@"^(.+) attacks alone$", 1)
        {

        }

        public override bool IsLeafRule()
        {
            return false;
        }
    }
}
