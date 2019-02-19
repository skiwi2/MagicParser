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
            var lexer = new MagicLexer();
            var tokens = lexer.CreateTokens(@"Archway Angel", @"Flying\nWhen Archway Angel enters the battlefield, you gain 2 life for each Gate you control.");
            PrettyPrintTokens(tokens);

            Console.WriteLine();

            var parser = new MagicParser();
            var root = parser.Parse(tokens);
            root.PrettyPrint(0, (indentation, text) => {
                Console.Write(string.Concat(Enumerable.Repeat(" ", (int)indentation * 2)));
                Console.WriteLine(text);
            });
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
