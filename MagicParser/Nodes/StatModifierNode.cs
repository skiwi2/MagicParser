using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Nodes
{
    public class StatModifierNode : INode
    {
        public INode Power { get; private set; }

        public INode Toughness { get; private set; }

        public StatModifierNode(INode power, INode toughness)
        {
            Power = power;
            Toughness = toughness;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(StatModifierNode));
            printer(indentation + 1, nameof(Power));
            Power.PrettyPrint(indentation + 2, printer);
            printer(indentation + 1, nameof(Toughness));
            Toughness.PrettyPrint(indentation + 2, printer);
        }

        public override string ToString()
        {
            return $"{nameof(StatModifierNode)}({Power}, {Toughness})";
        }
    }
}
