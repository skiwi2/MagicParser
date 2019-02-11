using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class ThoseRule : RegexRule
    {
        public ThoseRule() : base(@"^[Tt]hose (.+)$", 1)
        {

        }
    }
}
