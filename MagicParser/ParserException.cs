﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser
{
    public class ParserException : Exception
    {
        public ParserException(string message) : base(message)
        {

        }
    }
}
