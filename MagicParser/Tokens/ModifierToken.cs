using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class ModifierToken : IToken
    {
        public string Text { get; private set; }

        public ModifierToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(ModifierToken)}({Text})";
        }
    }
}
