using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
    public class ScopeNode
    {
        public ScopeNode Parent;

        public Dictionary<string, string> SymbolTable = new Dictionary<string, string>();

    }


    public class ScopeListener : GrammarBaseListener
    {
        ScopeNode currentScope;
        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context)
        {
            ScopeNode GlobalScope = new ScopeNode();
            currentScope = GlobalScope;
            base.EnterProgram(context);
        }
        public override void ExitProgram([NotNull] GrammarParser.ProgramContext context)
        {

            base.ExitProgram(context);
        }

        public override void EnterNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {
            if (context.ChildCount == 1)
            {
                if (!(int.TryParse(context.GetChild(0).GetText(), out var result)))
                {
                    LookUpScope(context.GetChild(0).GetText());
                }
            }
            //else if (context.ChildCount == 3)
            //{
            //    if (context.GetChild(0).ChildCount == 1 && !(int.TryParse(context.GetChild(0).GetText(), out var result)))
            //    {
            //        LookUpScope(context.GetChild(0).GetText());
            //    }

            //    if (context.GetChild(2).ChildCount == 1 && !(int.TryParse(context.GetChild(2).GetText(), out var result2)))
            //    {
            //        LookUpScope(context.GetChild(2).GetText());
            //    }
            //}

            base.EnterNum_expr(context);
        }

        public override void EnterIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            ScopeNode LocalScope = new ScopeNode();
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;

            base.EnterIter_stmt(context);
        }
        public override void ExitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitIter_stmt(context);
        }
        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var variableName = context.GetChild(1).GetText();
            var expression = context.GetChild(3).GetText();

            currentScope.SymbolTable.Add(variableName, expression);

            base.EnterVar_decl(context);
        }

        private void LookUpScope(string expression)
        {
            ScopeNode Scope = currentScope;

            do
            {
                if (Scope.SymbolTable.ContainsKey(expression))
                {
                    return;
                }
                else
                {
                    Scope = Scope.Parent;

                    if (Scope.SymbolTable.ContainsKey(expression))
                    {
                        return;
                    }
                }
            }
            while (Scope.Parent != null);

            throw new Exception($"Variable {expression} not in scopes");
        }

    }
}
