using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class ControlsRule : RegexRule
    {
        public ControlsRule() : base(@"^(.+) (.+) controls?$", 2)
        {

        }

        public override int Priority()
        {
            return -1;
        }
    }
}
