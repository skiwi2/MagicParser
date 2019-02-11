using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class MultipartRule : SplitRule
    {
        public MultipartRule() : base(@". ", OptionallyAddFinalDot)
        {

        }

        public override uint Priority()
        {
            return 4;
        }

        private static string OptionallyAddFinalDot(string text)
        {
            if (text[text.Length - 1] == '.')
            {
                return text;
            }
            else
            {
                return text + ".";
            }
        }
    }
}
