using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class PlayerToken : IToken
    {
        public static readonly PlayerToken You = new PlayerToken("you");

        public static readonly IList<PlayerToken> All = new List<PlayerToken> { You };

        public string Text { get; private set; }

        public PlayerToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(PlayerToken)}({Text})";
        }
    }
}
