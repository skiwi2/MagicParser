using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Nodes
{
    public class ControlsNode : INode
    {
        public INode Objects { get; private set; }

        public INode Owner { get; private set; }

        public ControlsNode(INode objects, INode owner)
        {
            Objects = objects;
            Owner = owner;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(ControlsNode));
            printer(indentation + 1, nameof(Objects));
            Objects.PrettyPrint(indentation + 2, printer);
            printer(indentation + 1, nameof(Owner));
            Owner.PrettyPrint(indentation + 2, printer);
        }

        public override string ToString()
        {
            return $"{nameof(ControlsNode)}({Objects}, {Owner})";
        }
    }
}
