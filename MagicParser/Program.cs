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
