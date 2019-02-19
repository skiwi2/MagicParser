using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Tokens;

namespace MagicParser.Nodes
{
    public class ActionNode : INode
    {
        public ActionToken ActionToken { get; private set; }

        public INode Left { get; private set; }

        public INode Right { get; private set; }

        public ActionNode(ActionToken actionToken, INode left, INode right)
        {
            ActionToken = actionToken;
            Left = left;
            Right = right;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(ActionNode));
            printer(indentation + 1, nameof(ActionToken));
            printer(indentation + 2, ActionToken.Text);
            printer(indentation + 1, nameof(Left));
            Left.PrettyPrint(indentation + 2, printer);
            printer(indentation + 1, nameof(Right));
            Right.PrettyPrint(indentation + 2, printer);
        }

        public override string ToString()
        {
            return $"{nameof(ActionNode)}({ActionToken}, {Left}, {Right})";
        }
    }
}
