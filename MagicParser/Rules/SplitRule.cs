using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public abstract class SplitRule : IRule
    {
        private string Delimiter { get; set; }

        private Func<string, string> SplitResultTransform { get; set; }

        public SplitRule(string delimiter) : this(delimiter, s => s)
        {
            
        }

        public SplitRule(string delimiter, Func<string, string> splitResultTransform)
        {
            Delimiter = delimiter;
            SplitResultTransform = splitResultTransform;
        }

        public virtual uint Priority()
        {
            return 1;
        }

        public bool IsLeafRule()
        {
            return false;
        }

        public bool IsApplicableFor(string text)
        {
            return text.Contains(Delimiter);
        }

        public IList<string> Parse(string text)
        {
            return text.Split(new string[] { Delimiter }, StringSplitOptions.None).Select(SplitResultTransform).ToList();
        }
    }
}
