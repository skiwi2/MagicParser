using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class VariableRule : ListRule
    {
        private static readonly IList<string> Variables = new List<string> {
            "X"
        };

        public VariableRule() : base(Variables, true)
        {

        }
    }
}
