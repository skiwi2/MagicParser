using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public interface IRule
    {
        bool IsLeafRule();

        bool IsApplicableFor(string text);

        IList<string> Parse(string text);
    }
}
