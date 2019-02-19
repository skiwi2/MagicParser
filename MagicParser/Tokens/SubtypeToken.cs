using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class SubtypeToken : IToken
    {
        public static readonly SubtypeToken Gate = new SubtypeToken("Gate");

        public static readonly IList<SubtypeToken> All = new List<SubtypeToken> { Gate };

        public string Text { get; private set; }

        public SubtypeToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(SubtypeToken)}({Text})";
        }
    }
}
