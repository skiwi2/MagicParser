using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class PhaseToken : IToken
    {
        public static readonly PhaseToken EndOfTurn = new PhaseToken("end of turn");

        public static IList<PhaseToken> All = new List<PhaseToken> { EndOfTurn };

        public string Text { get; private set; }

        public PhaseToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(PhaseToken)}({Text})";
        }
    }
}
