using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoombaCompiler2
{
    public class MainScopeClass
    {
        //public Dictionary<string, string> SymbolTable = new Dictionary<string, string>();
        public static List<ScopeNode> Scopes;        

        public static string ReturnValueFromScope(string variable)
        {
            foreach(var scope in Scopes)
            {
                if (scope.SymbolTable.ContainsKey(variable))
                {
                    return scope.SymbolTable[variable];                    
                }
            }

            return null;


        }

    }
    

}
