using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class ThisToken : IToken
    {
        public string Text { get; private set; }

        public ThisToken(string text)
        {
            Text = text;
        }
    }
}
