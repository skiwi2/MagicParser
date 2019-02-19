using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicParser.Tokens;

namespace MagicParser.Nodes
{
    public class ConstantNode<T> : INode where T : IToken
    {
        public T Token { get; private set; }

        public ConstantNode(T token)
        {
            Token = token;
        }

        public void PrettyPrint(uint indentation, Action<uint, string> printer)
        {
            printer(indentation, nameof(ConstantNode<T>));
            printer(indentation + 1, nameof(Token));
            printer(indentation + 2, Token.Text);
        }

        public override string ToString()
        {
            return $"{nameof(ConstantNode<T>)}({Token})";
        }
    }
}
