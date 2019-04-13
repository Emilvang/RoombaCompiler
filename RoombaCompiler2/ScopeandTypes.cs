using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoombaCompiler2
{
    public interface IScope
    {
        String GetScopeName(); 
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
        List<Symbol> Members { get; set; }
        Scope EnclosingScope { get; set; }

        public Scope() { }

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

        public String GetScopeName()
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
        public String Name; // All symbols at least have a name
        public Type Type; // Symbols have types

        public Symbol(string name, Type type)
        {
            Name = name;
            Type = type;
        }
    }

    public class VariableSymbol : Symbol
    {
        public VariableSymbol(String name, Type type) : base(name, type) { }
    }

}
