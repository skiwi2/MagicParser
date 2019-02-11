using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public abstract class ListRule : IRule
    {
        private IList<string> AlternativesList { get; set; }

        private bool CaseSensitive { get; set; }

        public ListRule(IList<string> alternativesList, bool caseSensitive)
        {
            AlternativesList = alternativesList;
            CaseSensitive = caseSensitive;
        }

        public virtual uint Priority()
        {
            return 1;
        }

        public bool IsLeafRule()
        {
            return true;
        }

        public bool IsApplicableFor(string text)
        {
            return TryGetOriginalText(text, out var _);
        }

        public IList<string> Parse(string text)
        {
            if (TryGetOriginalText(text, out var originalText))
            {
                return new List<string> { originalText };
            }
            else
            {
                throw new ParserException($"{text} not found in list of alternatives, matching case sensitive = {CaseSensitive}: {string.Join(", ", AlternativesList)}");
            }
        }

        private bool TryGetOriginalText(string text, out string originalText)
        {
            if (CaseSensitive)
            {
                originalText = AlternativesList.FirstOrDefault(alternative => alternative == text);
            }
            else
            {
                originalText = AlternativesList.FirstOrDefault(alternative => alternative.ToLower() == text.ToLower());
            }
            return originalText != null;
        }
    }
}
