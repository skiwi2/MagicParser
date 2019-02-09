using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new CardList(),
                new ZoneRule(),
                new ForEachRule(),
                new GainLifeRule(),
                new PlayerRule(),
                new NumberRule()
            });

            var text = @"When Archway Angel enters the battlefield, you gain 2 life for each Gate you control.";

            var node = parser.Parse(text);
            Console.WriteLine(node);
        }
    }
}
