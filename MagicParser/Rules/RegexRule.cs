using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class RegexRule : IRule
    {
        private Regex RuleRegex { get; set; }

        private uint MatchCount { get; set; }

        public RegexRule(string pattern, uint matchCount)
        {
            RuleRegex = new Regex(pattern, RegexOptions.Compiled);
            MatchCount = matchCount;
        }

        public bool IsLeafRule()
        {
            return MatchCount == 1;
        }

        public bool IsApplicableFor(string text)
        {
            return RuleRegex.IsMatch(text);
        }

        public IList<string> Parse(string text)
        {
            var match = RuleRegex.Match(text);
            if (match.Groups.Count != MatchCount + 1)
            {
                throw new ParserException($"Expected {MatchCount} matches, but found {match.Groups.Count - 1} matches on text: {text}");
            }
            // the first group is the complete string, we do not return that one
            return match.Groups.Cast<Group>().Skip(1).Select(group => group.Value).ToList();
        }
    }
}
