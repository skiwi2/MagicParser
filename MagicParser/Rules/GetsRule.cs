﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class GetsRule : RegexRule
    {
        public GetsRule() : base(@"^(.+?) gets? (.+)$", 2)
        {

        }
    }
}
