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
                new WhenRule()
            });

            var text = @"When Archway Angel enters the battlefield, you gain 2 life for each Gate you control.";

            var construct = parser.Parse(text);
            Console.WriteLine(construct);
        }
    }
}
