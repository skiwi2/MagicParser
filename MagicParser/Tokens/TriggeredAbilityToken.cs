using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class TriggeredAbilityToken : IToken
    {
        public static readonly TriggeredAbilityToken When = new TriggeredAbilityToken("When");

        public static readonly IList<TriggeredAbilityToken> All = new List<TriggeredAbilityToken> { When };

        public string Text { get; private set; }

        public TriggeredAbilityToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(TriggeredAbilityToken)}({Text})";
        }
    }
}
