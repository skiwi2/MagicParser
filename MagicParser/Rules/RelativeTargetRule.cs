using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class RelativeTargetRule : ListRule
    {
        private static IList<string> RelativeTargets = new List<string> {
            "it",
        };

        public RelativeTargetRule() : base(RelativeTargets, false)
        {

        }
    }
}
