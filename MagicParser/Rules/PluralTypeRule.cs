using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class PluralTypeRule : ListRule
    {
        private static readonly IList<string> PluralTypes = new List<string> {
            "creatures"
        };

        public PluralTypeRule() : base(PluralTypes, false)
        {

        }
    }
}
