using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class ContinuousEffectToken : IToken
    {
        public static readonly ContinuousEffectToken Until = new ContinuousEffectToken("until");

        public static readonly IList<ContinuousEffectToken> All = new List<ContinuousEffectToken> { Until };

        public string Text { get; private set; }

        public ContinuousEffectToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(ContinuousEffectToken)}({Text})";
        }
    }
}
