using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicParser.Nodes
{
    public interface INode
    {
        void PrettyPrint(uint indentation, Action<uint, string> printer);
    }
}
