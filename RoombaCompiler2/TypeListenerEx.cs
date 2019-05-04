using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
    public class TypeListenerEx : GrammarBaseListener
    {        

        private string[] SplitExpression(string expression)
        {
            string[] delimiters = { "*", "+", "/", "-" };
            return expression.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }





    }
}
