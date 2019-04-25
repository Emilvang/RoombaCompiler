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
        public List<Symbol> SymbolTable = new List<Symbol>();
    }

    /*public class Symbol
    {
        public string Name { get; set; }
        public string Type { get; set; }
        
    }
    
    public class FunctionSymbol : Symbol
    {
        public List<Symbol> Parameters { get; set; }
        public string ReturnType { get; set; }
    }*/
}
