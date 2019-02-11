using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Nodes;
using MagicParser.Rules;

namespace MagicParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser(new List<IRule> {
                new WhenRule(),
                new EntersRule(),
                new CardRule(),
                new ZoneRule(),
                new ForEachRule(),
                new GainLifeRule(),
                new PlayerRule(),
                new NumberRule(),
                new ControlsRule(),
                new SubtypeRule(),
                new KeywordRule(),
                new UntilEndOfTurnRule(),
                new DamageThatWouldReduceYourLifeRule(),
                new MultilineRule(),
                new AbilityRule(),
                new CostRule(),
                new ManaCostRule(),
                new ExileRule(),
                new LifeTotalBecomesRule(),
                new WheneverRule(),
                new AttacksAloneRule(),
                new AnyRule(),
                new TypeRule(),
                new WhereRule(),
                new VariableRule(),
                new IsRule(),
                new GetsRule(),
                new RelativeTargetRule(),
                new StatModifierRule(),
                new ZoneRule(),
                new NumberOfRule(),
                new TargetRule(),
                new AddendumRule(),
                new GainsRule(),
                new ThatRule(),
                new SimpleRule()
            });

            var texts = new List<string> {
                // Angel of Grace
                @"Flash\nFlying\nWhen Angel of Grace enters the battlefield, until end of turn, damage that would reduce your life total to less than 1 reduces it to 1 instead.\n{4}{W}{W}, Exile Angel of Grace from your graveyard: Your life total becomes 10.",
                // Angelic Exaltation
                @"Whenever a creature you control attacks alone, it gets +X/+X until end of turn, where X is the number of creatures you control.",
                // Archway Angel
                @"Flying\nWhen Archway Angel enters the battlefield, you gain 2 life for each Gate you control.",
                // Arrester's Zeal
                @"Target creature gets +2/+2 until end of turn.\nAddendum — If you cast this spell during your main phase, that creature gains flying until end of turn.",
                // Sylvan Brushstrider
                @"When Sylvan Brushstrider enters the battlefield, you gain 2 life."
            };

            foreach (var text in texts)
            {
                var node = parser.Parse(text);
                PrettyPrint(node, 0);
                Console.WriteLine();
            }
        }

        private static void PrettyPrint(INode node, int indentation)
        {
            Console.Write(string.Concat(Enumerable.Repeat(" ", indentation)));
            switch (node)
            {
                case Node n:
                    Console.WriteLine(n.Rule.GetType().Name + ":");
                    foreach (var childNode in n.Nodes)
                    {
                        PrettyPrint(childNode, indentation + 2);
                    }
                    break;
                case LeafNode leafNode:
                    Console.WriteLine(leafNode.Rule.GetType().Name + ": " + leafNode.Value);
                    break;
            }
        }
    }
}
