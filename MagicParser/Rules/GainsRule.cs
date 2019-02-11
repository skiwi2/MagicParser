using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class GainsRule : RegexRule
    {
        public GainsRule() : base(@"^(.+?) gains (.+)$", 2)
        {

        }
    }
}
