using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class ForEachRule : RegexRule
    {
        public ForEachRule() : base(@"^(.+) for each (.+)$", 2)
        {

        }
    }
}
