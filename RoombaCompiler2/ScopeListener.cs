using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
        

    public class ScopeListener : GrammarBaseListener
    {
        ScopeNode currentScope;
        public List<ScopeNode> Scopes = new List<ScopeNode>();
        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context)
        {
            ScopeNode GlobalScope = new ScopeNode();
            Scopes.Add(GlobalScope);
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

            base.EnterNum_expr(context);
        }

        public override void EnterLogic_expr([NotNull] GrammarParser.Logic_exprContext context)
        {



            base.EnterLogic_expr(context);
        }
        public override void ExitLogic_expr([NotNull] GrammarParser.Logic_exprContext context)
        {
            base.ExitLogic_expr(context);
        }

        public override void EnterIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;

            base.EnterIter_stmt(context);
        }
        public override void ExitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitIter_stmt(context);
        }

        public override void EnterCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;
            base.EnterCond_stmt(context);
        }
        public override void ExitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitCond_stmt(context);
        }

        //Should it be Func_expr or Func_stmt?
        public override void EnterFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;
            base.EnterFunc_expr(context);
        }
        public override void ExitFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitFunc_expr(context);
        }

        //Needs check that variable doesn't exist in parents.
        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {



            var variableName = context.GetChild(1).GetText();
            var expression = context.GetChild(3).GetText();


            if (!LookUpScope(variableName))
            {
                currentScope.SymbolTable.Add(variableName, expression);
            }
            else
            {
                throw new Exception("Variable already exists in local or parent scopes!");
            }                                

            base.EnterVar_decl(context);
        }

        private bool LookUpScope(string expression)
        {
            ScopeNode Scope = currentScope;

            do
            {
                if (Scope.SymbolTable.ContainsKey(expression))
                {
                    return true;
                }
                else
                {
                    Scope = Scope.Parent;

                    if (Scope == null)
                    {
                        return false;
                    }

                    if (Scope.SymbolTable.ContainsKey(expression))
                    {
                        return true;
                    }
                }
            }
            while (Scope.Parent != null);

            return false;
        }

        

    }
}
