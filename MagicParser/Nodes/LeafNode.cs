using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Rules;

namespace MagicParser.Nodes
{
    public class LeafNode : INode
    {
        public IRule Rule { get; private set; }

        public string Value { get; private set; }

        public LeafNode(IRule rule, string value)
        {
            Rule = rule;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Rule.GetType().Name}({Value})";
        }
    }
}
