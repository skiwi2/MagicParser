using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class ListRule : IRule
    {
        private IList<string> AlternativesList { get; set; }

        public ListRule(IList<string> alternativesList)
        {
            AlternativesList = alternativesList;
        }

        public bool IsLeafRule()
        {
            return true;
        }

        public bool IsApplicableFor(string text)
        {
            return AlternativesList.Contains(text);
        }

        public IList<string> Parse(string text)
        {
            if (AlternativesList.Contains(text))
            {
                return new List<string> { text };
            }
            else
            {
                throw new ParserException($"{text} not found in list of alternatives: {string.Join(", ", AlternativesList)}");
            }
        }
    }
}
