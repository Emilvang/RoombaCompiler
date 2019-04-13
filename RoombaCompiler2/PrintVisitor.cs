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
        public Stack<Scope> ScopeStack { get; set; } 

        public override bool VisitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            Console.WriteLine(context.ChildCount);
            //GlobalScope = new Scope()
            Console.WriteLine("Program");
            ScopeStack = new Stack<Scope>();
            ScopeStack.Push(new Scope());
            
            

            return base.VisitProgram(context);
        }

        public override bool VisitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            Console.WriteLine("Conditional statement");
            return base.VisitCond_stmt(context);
        }
        public override bool VisitStmts([NotNull] GrammarParser.StmtsContext context)
        {
            Console.WriteLine("Statements");
            return base.VisitStmts(context);
        }

        public override bool VisitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            Console.WriteLine("Function statement");
            //(Console.WriteLine(context.Ch);

            ScopeStack.Push(new Scope());
            foreach(Antlr4.Runtime.Tree.IParseTree tree in context.children)
            {
                Console.WriteLine(tree.GetType().ToString());
                
                
            }
            
            
            return base.VisitFunc_stmt(context);
        }

        public override bool VisitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            Console.WriteLine("Iterative statement");
            return base.VisitIter_stmt(context);
        }

        public override bool VisitExpr([NotNull] GrammarParser.ExprContext context)
        {
            Console.WriteLine("Expression");
            return base.VisitExpr(context);
        }

        public override bool VisitVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            Console.WriteLine("Var Statement " + context.GetText());

            return base.VisitVar_stmt(context);
        }

        public override bool VisitStmt([NotNull] GrammarParser.StmtContext context)
        {
            Console.WriteLine("Statement");

            return base.VisitStmt(context);
        }

        public override bool VisitFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            Console.WriteLine("Function Expression");

            return base.VisitFunc_expr(context);
        }


        public override bool VisitVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            Console.WriteLine("Variable Declaration " + context.GetText());

            return base.VisitVar_decl(context);
        }

        public override bool VisitVar_expr([NotNull] GrammarParser.Var_exprContext context)
        {
            Console.WriteLine(context.GetText());
            return base.VisitVar_expr(context);
        }
        public override bool VisitPrint([NotNull] GrammarParser.PrintContext context)
        {
            Console.WriteLine("Print");
            return base.VisitPrint(context);
        }

        public override bool VisitNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {
            Console.WriteLine($"Numeric Expression {context.GetText()}");

            return base.VisitNum_expr(context);
        }
    }
}
