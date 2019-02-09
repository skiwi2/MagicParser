using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class SubtypeRule : ListRule
    {
        private static readonly IList<string> Subtypes = new List<string>
        {
            "Gate"
        };

        public SubtypeRule() : base(Subtypes)
        {

        }
    }
}
