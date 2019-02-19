using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Nodes
{
    public class ForEachNode : INode
    {
        public INode Action { get; private set; }

        public INode Condition { get; private set; }

        public ForEachNode(INode action, INode condition)
        {
            Action = action;
            Condition = condition;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(ForEachNode));
            printer(indentation + 1, nameof(Action));
            Action.PrettyPrint(indentation + 2, printer);
            printer(indentation + 1, nameof(Condition));
            Condition.PrettyPrint(indentation + 2, printer);
        }

        public override string ToString()
        {
            return $"{nameof(ForEachNode)}({Action}, {Condition})";
        }
    }
}
