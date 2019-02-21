using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Nodes
{
    public class ContinuousEffectNode : INode
    {
        public INode Phase { get; private set; }

        public INode Action { get; private set; }

        public ContinuousEffectNode(INode phase, INode action)
        {
            Phase = phase;
            Action = action;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(ContinuousEffectNode));
            printer(indentation + 1, nameof(Phase));
            Phase.PrettyPrint(indentation + 2, printer);
            printer(indentation + 1, nameof(Action));
            Action.PrettyPrint(indentation + 2, printer);
        }

        public override string ToString()
        {
            return $"{nameof(ContinuousEffectNode)}({Phase}, {Action})";
        }
    }
}
