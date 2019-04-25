using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
    class CodeGenVisitor : GrammarBaseVisitor<string>
    {
        public string GeneratedCode { get; set; }
        public string prefix = "\r\n\t";
        
        public CodeGenVisitor()
        {
            GeneratedCode = "";
        }

        public override string VisitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            
            GeneratedCode += " def " + context.GetChild(1) + "(";
            return base.VisitFunc_stmt(context);
        }

        public override string VisitParameter_decl([NotNull] GrammarParser.Parameter_declContext context)
        {
            return context.GetChild(context.children.Count() - 1).GetText();
        }

        private string removePrefix(string sourceString, string removeString)
        {
            int index = sourceString.IndexOf(removeString);
            string cleanPath = (index < 0)
                ? sourceString
                : sourceString.Remove(index, removeString.Length);

            return cleanPath;

        }

    }
}
