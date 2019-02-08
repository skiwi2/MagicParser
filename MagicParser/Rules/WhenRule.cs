using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class WhenRule : IRule
    {
        private static readonly Regex RuleRegex = new Regex(@"^When (.+)\, (.+)\.$", RegexOptions.Compiled);

        public bool IsApplicableFor(string text)
        {
            return RuleRegex.IsMatch(text);
        }

        public IList<string> Parse(string text)
        {
            var match = RuleRegex.Match(text);
            if (match.Groups.Count != 3)
            {
                throw new ParserException($"Expected 2 matches, but found {match.Groups.Count - 1} matches on text: {text}");
            }
            var when = match.Groups[1].Value;
            var then = match.Groups[2].Value;
            return new List<string> { when, then };
        }
    }
}
