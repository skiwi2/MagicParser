using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class DamageThatWouldReduceYourLifeRule : RegexRule
    {
        public DamageThatWouldReduceYourLifeRule() : base(@"^damage that would reduce your life total to less than (\d+) reduces it to (\d+) instead$", 2)
        {

        }
    }
}
