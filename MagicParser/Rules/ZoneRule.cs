using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class ZoneRule : ListRule
    {
        private static readonly IList<string> Zones = new List<string> {
            "battlefield"
        };

        public ZoneRule() : base(Zones)
        {

        }
    }
}
