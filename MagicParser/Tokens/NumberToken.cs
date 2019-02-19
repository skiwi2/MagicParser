using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class NumberToken : IToken
    {
        public string Text { get; private set; }

        public NumberToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(NumberToken)}({Text})";
        }
    }
}
