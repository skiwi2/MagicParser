using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class KeywordRule : ListRule
    {
        private static readonly IList<string> Keywords = new List<string> {
            "Addendum",
            "Flash",
            "Flying",
            "Scry"
        };

        public KeywordRule() : base(Keywords, false)
        {

        }
    }
}
