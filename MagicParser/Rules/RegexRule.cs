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
        private IList<Regex> RuleRegexes { get; set; }

        private uint MatchCount { get; set; }

        public RegexRule(string pattern, uint matchCount) : this(new List<string> { pattern }, matchCount)
        {
            
        }

        public RegexRule(IList<string> patterns, uint matchCount)
        {
            RuleRegexes = patterns.Select(pattern => new Regex(pattern, RegexOptions.Compiled)).ToList();
            MatchCount = matchCount;
        }

        public virtual uint Priority()
        {
            return 1;
        }

        public virtual bool IsLeafRule()
        {
            return false;
        }

        public bool IsApplicableFor(string text)
        {
            return RuleRegexes.Any(ruleRegex => ruleRegex.IsMatch(text));
        }

        public IList<string> Parse(string text)
        {
            foreach (var ruleRegex in RuleRegexes)
            {
                var match = ruleRegex.Match(text);
                if (match.Success)
                {
                    if (match.Groups.Count - 1 != MatchCount)
                    {
                        throw new ParserException($"Expected {MatchCount} matches, but found {match.Groups.Count - 1} matches on text: {text}");
                    }
                    // the first group is the complete string, we do not return that one
                    return match.Groups.Cast<Group>().Skip(1).Select(group => group.Value).ToList();
                }
            }
            throw new ParserException($"Found no matching regex for text: {text}");
        }
    }
}
