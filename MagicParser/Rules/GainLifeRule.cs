using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class GainLifeRule : RegexRule
    {
        public GainLifeRule() : base(@"^(.+) gains? (\d+) life$", 2)
        {

        }
    }
}
