using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Rules;

namespace MagicParser
{
    public class Parser
    {
        private IList<IRule> Rules { get; set; }

        public Parser(IList<IRule> rules)
        {
            Rules = rules;
        }

        public Construct Parse(string text)
        {
            var applicableRule = Rules.FirstOrDefault(rule => rule.IsApplicableFor(text));
            if (applicableRule == null)
            {
                throw new ParserException($"Failed to find applicable rule for: {text}");
            }
            var results = applicableRule.Parse(text);
            var constructs = results.Select(result => Parse(result));
            return new Construct(applicableRule, constructs.ToList());
        }
    }
}
