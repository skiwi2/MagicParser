using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Rules;

namespace MagicParser.Nodes
{
    public class Node : INode
    {
        public IRule Rule { get; private set; }

        public IList<INode> Nodes { get; private set; }

        public Node(IRule rule, IList<INode> nodes)
        {
            Rule = rule;
            Nodes = nodes;
        }

        public override string ToString()
        {
            return $"{Rule.GetType().Name}({string.Join(", ", Nodes)})";
        }
    }
}
