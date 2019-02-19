using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Nodes
{
    public class MultilineNode : INode
    {
        public INode Left { get; private set; }

        public INode Right { get; private set; }

        public MultilineNode(INode left, INode right)
        {
            Left = left;
            Right = right;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(MultilineNode));
            printer(indentation + 1, nameof(Left));
            Left.PrettyPrint(indentation + 2, printer);
            printer(indentation + 1, nameof(Right));
            Right.PrettyPrint(indentation + 2, printer);
        }

        public override string ToString()
        {
            return $"{nameof(MultilineNode)}({Left}, {Right})";
        }
    }
}
