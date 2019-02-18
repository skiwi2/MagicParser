using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class PunctuationToken : IToken
    {
        public static readonly PunctuationToken Space = new PunctuationToken(" ");
        public static readonly PunctuationToken Comma = new PunctuationToken(",");
        public static readonly PunctuationToken Dot = new PunctuationToken(".");
        public static readonly PunctuationToken NewLine = new PunctuationToken(@"\n");

        public static readonly IList<PunctuationToken> All = new List<PunctuationToken> { Space, Comma, Dot, NewLine };

        public string Text { get; private set; }

        public PunctuationToken(string text)
        {
            Text = text;
        }
    }
}
