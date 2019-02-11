﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class NumberRule : RegexRule
    {
        public NumberRule() : base(@"^(\d+)$", 1)
        {

        }

        public override bool IsLeafRule()
        {
            return true;
        }
    }
}
