﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class StatModifierRule : RegexRule
    {
        public StatModifierRule() : base(@"^([\+\-].+?/[\+\-].+)$", 1)
        {

        }

        public override bool IsLeafRule()
        {
            return true;
        }
    }
}
