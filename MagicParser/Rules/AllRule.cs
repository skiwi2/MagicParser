using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class AllRule : ReplacementRule
    {
        private static readonly IDictionary<string, string> Replacements = new Dictionary<string, string>
        {
            { "creatures", "creature" }
        };

        public AllRule() : base(Replacements, false)
        {

        }
    }
}
