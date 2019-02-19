using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Tokens;

namespace MagicParser.Nodes
{
    public class ResourceNode : INode
    {
        public ResourceToken ResourceToken { get; private set; }

        public INode Number { get; private set; }

        public ResourceNode(ResourceToken resourceToken, INode number)
        {
            ResourceToken = resourceToken;
            Number = number;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(ResourceNode));
            printer(indentation + 1, nameof(ResourceToken));
            printer(indentation + 2, ResourceToken.Text);
            printer(indentation + 1, nameof(Number));
            Number.PrettyPrint(indentation + 2, printer);
        }

        public override string ToString()
        {
            return $"{nameof(ResourceNode)}({ResourceToken}, {Number})";
        }
    }
}
