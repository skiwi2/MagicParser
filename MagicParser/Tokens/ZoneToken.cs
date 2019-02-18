using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class ZoneToken : IToken
    {
        public static readonly ZoneToken Battlefield = new ZoneToken("the battlefield");

        public static readonly IList<ZoneToken> All = new List<ZoneToken> { Battlefield };

        public string Text { get; private set; }

        public ZoneToken(string text)
        {
            Text = text;
        }
    }
}
