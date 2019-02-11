using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class PlayerRule : ListRule
    {
        private static readonly IList<string> Players = new List<string>
        {
            "you"
        };

        public PlayerRule() : base(Players, false)
        {

        }
    }
}
