﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Rules
{
    public class CardRule : ListRule
    {
        private static readonly IList<string> Cards = new List<string> {
            "Angel of Grace",
            "Archway Angel"
        };

        public CardRule() : base(Cards)
        {

        }
    }
}
