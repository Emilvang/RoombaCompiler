using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoombaCompiler2
{
    public interface IScope
    {
        string GetScopeName(); 
        Scope GetEnclosingScope(); 
        void Define(Symbol sym); 
        Symbol Resolve(string name); 

    }

    public interface IType
    {
        String GetName();
    }

    public class Scope : IScope
    {
        public List<Symbol> Members { get; set; }
        public Scope EnclosingScope { get; set; }

        public Scope() { Members = new List<Symbol>(); }
        public Scope (Scope enclosingScope)
        {
            Members = new List<Symbol>();
            EnclosingScope = enclosingScope;
        }
        public Scope (List<Symbol> symbols)
        {
            Members = symbols;
        }

        public Scope (Scope enclosingScope, List<Symbol> symbols)
        {
            EnclosingScope = enclosingScope;
            Members = symbols;
        }

        public Symbol Resolve(string name)
        {
            Symbol s = Members.FirstOrDefault(x => x.Name == name);
            if (s != null)
                return s;
            else if (EnclosingScope != null)
                return EnclosingScope.Resolve(name);
            else
                return null;
        }

        public string GetScopeName()
        {
            return "g";
        }

        public Scope GetEnclosingScope() { return EnclosingScope; }

        public void Define(Symbol sym)
        {

        }

    }

    public class Symbol
    {
        public string Name; // All symbols at least have a name
        public string Type; 

        public Symbol(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public class VariableSymbol : Symbol
    {
        public VariableSymbol(string name, string type) : base(name, type) { }
    }

}
