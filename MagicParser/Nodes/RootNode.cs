using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Nodes
{
    public class RootNode : INode
    {
        public IList<INode> Nodes { get; private set; }

        public RootNode(IList<INode> nodes)
        {
            Nodes = nodes;
        }

        public override string ToString()
        {
            return $"Root({string.Join(", ", Nodes)})";
        }
    }
}
