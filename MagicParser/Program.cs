using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Tokens;

namespace MagicParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cards = new Dictionary<string, string>
            {
                { @"Archway Angel", @"Flying\nWhen Archway Angel enters the battlefield, you gain 2 life for each Gate you control." },
                { @"Civic Stalwart", @"When Civic Stalwart enters the battlefield, creatures you control get +1/+1 until end of turn." }
            };

            var lexer = new MagicLexer();
            var parser = new MagicParser();

            foreach (var kvp in cards)
            {
                var tokens = lexer.CreateTokens(kvp.Key, kvp.Value);
                PrettyPrintTokens(tokens);

                Console.WriteLine();

                var root = parser.Parse(tokens);
                root.PrettyPrint(0, (indentation, text) => {
                    Console.Write(string.Concat(Enumerable.Repeat(" ", (int)indentation * 2)));
                    Console.WriteLine(text);
                });

                Console.WriteLine();
            }
        }

        private static void PrettyPrintTokens(IEnumerable<IToken> tokens)
        {
            foreach (var token in tokens)
            {
                Console.WriteLine($"{token.GetType().Name}({token.Text})");
            }
        }
    }
}
