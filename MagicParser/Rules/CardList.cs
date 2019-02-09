using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class CardList : ListRule
    {
        private static readonly IList<string> Cards = new List<string> {
            "Archway Angel"
        };

        public CardList() : base(Cards)
        {

        }
    }
}
