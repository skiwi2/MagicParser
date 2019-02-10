﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public interface IRule
    {
        uint Priority();

        bool IsLeafRule();

        bool IsApplicableFor(string text);

        IList<string> Parse(string text);
    }
}
