using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class ActionToken : IToken
    {
        public static readonly ActionToken Enters = new ActionToken("enters");
        public static readonly ActionToken Gains = new ActionToken("gain");

        public static readonly IList<ActionToken> All = new List<ActionToken> { Enters, Gains };

        public string Text { get; private set; }

        public ActionToken(string text)
        {
            Text = text;
        }
    }
}
