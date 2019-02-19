using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Nodes
{
    public class TriggeredAbilityNode : INode
    {
        public INode When { get; private set; }

        public INode Then { get; private set; }

        public TriggeredAbilityNode(INode when, INode then)
        {
            When = when;
            Then = then;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(TriggeredAbilityNode));
            printer(indentation + 1, nameof(When));
            When.PrettyPrint(indentation + 2, printer);
            printer(indentation + 1, nameof(Then));
            Then.PrettyPrint(indentation + 2, printer);
        }

        public override string ToString()
        {
            return $"{nameof(TriggeredAbilityNode)}({When}, {Then})";
        }
    }
}
