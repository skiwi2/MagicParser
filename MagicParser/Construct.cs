using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Rules;

namespace MagicParser
{
    public class Construct
    {
        public IRule Rule { get; private set; }

        public IList<Construct> Constructs { get; private set; }

        public Construct(IRule rule, IList<Construct> constructs)
        {
            Rule = rule;
            Constructs = constructs;
        }

        public override string ToString()
        {
            return $"{Rule.GetType().Name}({string.Join(", ", Constructs)})";
        }
    }
}
