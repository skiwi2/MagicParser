using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Nodes;
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

        public INode Parse(string text)
        {
            var applicableRule = Rules.OrderByDescending(rule => rule.Priority()).FirstOrDefault(rule => rule.IsApplicableFor(text));
            if (applicableRule == null)
            {
                throw new ParserException($"Failed to find applicable rule for: {text}");
            }
            var results = applicableRule.Parse(text);
            if (applicableRule.IsLeafRule())
            {
                return new LeafNode(applicableRule, results[0]);
            }
            else
            {
                var nodes = results.Select(result => Parse(result));
                return new Node(applicableRule, nodes.ToList());
            }
        }
    }
}
