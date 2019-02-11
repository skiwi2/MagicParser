using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class AnyRule : RegexRule
    {
        public AnyRule() : base(@"^(?:a|any) (.+)$", 1)
        {

        }
    }
}
