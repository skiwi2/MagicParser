using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class CardRule : ListRule
    {
        private static readonly IList<string> Cards = new List<string> {
            "Angel of Grace",
            "Archway Angel",
            "Civic Stalwart",
            "Forbidding Spirit",
            "Sylvan Brushstrider"
        };

        public CardRule() : base(Cards, true)
        {

        }
    }
}
