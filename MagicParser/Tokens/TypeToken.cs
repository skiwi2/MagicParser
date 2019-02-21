using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class TypeToken : IToken
    {
        public static readonly TypeToken Creatures = new TypeToken("creatures");

        public static readonly IList<TypeToken> All = new List<TypeToken> { Creatures };

        public string Text { get; private set; }

        public TypeToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(TypeToken)}({Text})";
        }
    }
}
