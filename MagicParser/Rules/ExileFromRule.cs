using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class ExileFromRule : RegexRule
    {
        public ExileFromRule() : base(@"^Exile (.+) from (.+)$", 2)
        {

        }
    }
}
