using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class KeywordToken : IToken
    {
        public static readonly KeywordToken Flying = new KeywordToken("Flying");

        public static readonly IList<KeywordToken> All = new List<KeywordToken> { Flying };

        public string Text { get; private set; }

        public KeywordToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(KeywordToken)}({Text})";
        }
    }
}
