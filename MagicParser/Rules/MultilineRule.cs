using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class MultilineRule : IRule
    {
        public uint Priority()
        {
            return 4;
        }

        public bool IsLeafRule()
        {
            return false;
        }

        public bool IsApplicableFor(string text)
        {
            return text.Contains(@"\n");
        }

        public IList<string> Parse(string text)
        {
            return text.Split(new string[] { @"\n" }, StringSplitOptions.None);
        }
    }
}
