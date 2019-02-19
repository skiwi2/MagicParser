using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class Token : IToken
    {
        public static readonly Token ForEach = new Token("for each");
        public static readonly Token Control = new Token("control");

        public static readonly IList<Token> All = new List<Token> { ForEach, Control };

        public string Text { get; private set; }

        public Token(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(Token)}({Text})";
        }
    }
}
