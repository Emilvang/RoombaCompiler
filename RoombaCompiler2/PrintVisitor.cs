using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
    public class PrintVisitor : GrammarBaseVisitor<bool>
    {
        public override bool VisitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            Console.WriteLine("Program");

            return base.VisitProgram(context);
        }

        public override bool VisitVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            Console.WriteLine("Var Statement");

            return base.VisitVar_stmt(context);
        }

        public override bool VisitStmt([NotNull] GrammarParser.StmtContext context)
        {
            Console.WriteLine("Statement");

            return base.VisitStmt(context);
        }

        public override bool VisitFunction_expr([NotNull] GrammarParser.Function_exprContext context)
        {
            Console.WriteLine("Expression");

            return base.VisitFunction_expr(context);
        }

        public override bool VisitNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {
            Console.WriteLine($"Numeric Expression {context.GetText()}");

            return base.VisitNum_expr(context);
        }
    }
}
