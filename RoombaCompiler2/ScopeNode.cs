using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoombaCompiler2
{
    public class ScopeNode
    {
        public ScopeNode Parent;

        public List<Symbol> SymbolTable = new List<Symbol>();


    }

    public class Symbol
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsFunction { get; set; }

        public Symbol(string name, string type)
        {
            Name = name;
            Type = type;
            IsFunction = false;
        }
    }

    public class FunctionSymbol : Symbol
    {
        public List<Symbol> Parameters { get; set; }

        public FunctionSymbol(string name, string type, List<Symbol> parameters) : base (name, type)
        {
            Parameters = parameters;
            IsFunction = true;
        }
    }
}
