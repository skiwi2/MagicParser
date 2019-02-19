using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Tokens
{
    public class ResourceToken : IToken
    {
        public static readonly ResourceToken Life = new ResourceToken("life");

        public static readonly IList<ResourceToken> All = new List<ResourceToken> { Life };

        public string Text { get; private set; }

        public ResourceToken(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(ResourceToken)}({Text})";
        }
    }
}
