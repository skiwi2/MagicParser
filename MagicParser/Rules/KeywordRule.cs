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
            "Flying",
            "Flash"
        };

        public KeywordRule() : base(Keywords, false)
        {

        }
    }
}
