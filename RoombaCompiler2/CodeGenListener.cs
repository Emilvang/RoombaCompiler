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
        public CodeGenVisitor()
        {
            GeneratedCode = "";
        }

        public override string VisitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            Console.WriteLine("fwfw");
            GeneratedCode += " def " + context.GetChild(1) + "(";
            return base.VisitFunc_stmt(context);
        }

        public override string VisitParameter_decl([NotNull] GrammarParser.Parameter_declContext context)
        {
            return context.GetChild(context.children.Count() - 1).GetText();
        }

    }
}
