using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public abstract class ReplacementRule : IRule
    {
        private IDictionary<string, string> ReplacementsMap { get; set; }

        private IDictionary<string, string> ReplacementsLowercaseMap { get; set; }

        private bool CaseSensitive { get; set; }

        public ReplacementRule(IDictionary<string, string> replacementsMap, bool caseSensitive)
        {
            ReplacementsMap = replacementsMap;
            ReplacementsLowercaseMap = new Dictionary<string, string>(replacementsMap, StringComparer.OrdinalIgnoreCase);
            CaseSensitive = caseSensitive;
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
            return TryGetReplacement(text, out var _);
        }

        public IList<string> Parse(string text)
        {
            if (TryGetReplacement(text, out var replacementText))
            {
                return new List<string> { replacementText };
            }
            else
            {
                throw new ParserException($"{text} not found in map of replacements, matching case sensitive = {CaseSensitive}: {string.Join(", ", ReplacementsMap)}");
            }
        }

        private bool TryGetReplacement(string text, out string replacementText)
        {
            if (CaseSensitive)
            {
                return ReplacementsMap.TryGetValue(text, out replacementText);
            }
            else
            {
                return ReplacementsLowercaseMap.TryGetValue(text, out replacementText);
            }
        }
    }
}
