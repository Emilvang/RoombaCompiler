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
        // Variables outside program are not registered.
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


            if (context.GetChild(0).GetText() == "for")
            {
                currentScope.SymbolTable.Add(context.GetChild(1).GetText(), context.GetChild(3).GetText());
            }


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


        public override void EnterArithmetic_expr([NotNull] GrammarParser.Arithmetic_exprContext context)
        {
            Console.WriteLine("ARITH"  + context.GetText());
            base.EnterArithmetic_expr(context);
        }
        public override void EnterVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            if (!LookUpScope(context.GetChild(0).GetText()))
                throw new Exception("Cant find variable " + context.GetChild(0).GetText());
            base.EnterVar_stmt(context);
        }

        public override void ExitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitCond_stmt(context);
        }

        //Should it be Func_expr or Func_stmt?
        public override void EnterFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            base.EnterFunc_expr(context);
        }
        public override void ExitFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            base.ExitFunc_expr(context);
        }
        //Needs variable dec. for parametres
        public override void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;


            //3 because here the arguments begin.
            int count2 = 3;
            //Probably needs an escape or exception thrown somehow if the programmer makes an error. What happens if the programmer forgets a comma?
            //Cant handle no arguments.
            while (true)
            {
                var variableName = context.GetChild(count2).GetChild(1).GetText();


                //null for now, because the variable doesn't have a value at this stage.
                //Might need other solution later. 
                if (!LookUpScope(variableName))
                {
                    currentScope.SymbolTable.Add(variableName, null);
                }
                else
                {
                    throw new Exception("Variable already exists in local or parent scopes!");
                }
                //Checking if the next child is ')', meaning it has reached the end of the arguments. Break if so, else continue.
                if (context.GetChild(count2 + 1).GetText() == ")") break;

                else count2 += 2;
            }



            base.EnterFunc_stmt(context);
        }

        public override void ExitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitFunc_stmt(context);
        }

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var variableName = context.GetChild(1).GetText();
            var expression = context.GetChild(3).GetText();
            Console.WriteLine(context.GetChild(3).GetText());

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

            while (Scope != null)
            {
                if (Scope.SymbolTable.ContainsKey(expression))
                {
                    return true;
                }
                else
                {
                    Scope = Scope.Parent;
                }
            }

            return false;
        }



    }
}
