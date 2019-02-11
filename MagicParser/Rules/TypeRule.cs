using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class TypeRule : ListRule
    {
        private static readonly IList<string> Types = new List<string> {
            "creature"
        };

        public TypeRule() : base(Types, false)
        {

        }
    }
}
