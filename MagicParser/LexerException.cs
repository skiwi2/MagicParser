using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser
{
    public class LexerException : Exception
    {
        public LexerException(string message) : base(message)
        {

        }
    }
}
