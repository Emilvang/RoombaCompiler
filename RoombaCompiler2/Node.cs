using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoombaCompiler2
{
    public class Node
    {
        public List<Node> children = new List<Node>();
        public Node parent;
        public Dictionary<string, object> Scope = new Dictionary<string, object>();
    }
}
