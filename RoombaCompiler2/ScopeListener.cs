using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{

    /* Scopes to check:
     * var decl DONE
     * func expr
     * var expr
     * 
     * 
     * Variables to add to scopes:
     * for
     * parameters
     * func_stmt
     * 
     * Add scopes:
     * Iter stmt
     * if  / else /elseif
     */
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

        public override void EnterVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            LookUpScope(context.GetChild(0).GetText());
            base.EnterVar_stmt(context);
        }

        public override void EnterVar_expr([NotNull] GrammarParser.Var_exprContext context)
        {
            if (!LookUpScope(context.GetChild(0).GetText()))
                throw new Exception("Variable " + context.GetText() + " could not be found in scope");
            base.EnterVar_expr(context);
        }

        public override void ExitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitCond_stmt(context);
        }

        //Should it be Func_expr or Func_stmt?
        public override void EnterFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            if(!LookUpScope(context.GetChild(0).GetText()))
                throw new Exception("Function " + context.GetChild(0).GetText() + " not found");

            base.EnterFunc_expr(context);
        }
        //Needs variable dec. for parametres
        public override void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            if(!LookUpScope(context.GetChild(1).GetText()))
                currentScope.SymbolTable.Add(context.GetChild(1).GetText(), context.GetChild(0).GetText());
            else
                throw new Exception("A function or variable named " + context.GetChild(1).GetText() + " already exists");

            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;



            //3 because here the arguments begin.
            /*int count2 = 3;
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
            }*/



            base.EnterFunc_stmt(context);
        }

        public override void EnterParameter_decl([NotNull] GrammarParser.Parameter_declContext context)
        {
            var variableName = context.GetChild(1).GetText();
            var varType = context.GetChild(0).GetText();
            currentScope.SymbolTable.Add(variableName, varType); 
            base.EnterParameter_decl(context);
        }
        public override void ExitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitFunc_stmt(context);
        }

        //DONE 
        //Only looks up current scope because it can be declared locally after being declared globally
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

        public override void EnterIf_stmt([NotNull] GrammarParser.If_stmtContext context)
        {
            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;
            base.EnterIf_stmt(context);
        }

        public override void ExitIf_stmt([NotNull] GrammarParser.If_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitIf_stmt(context);
        }

        public override void EnterElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context)
        {
            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;
            base.EnterElseif_stmt(context);
        }

        public override void ExitElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitElseif_stmt(context);
        }

        public override void EnterElse_stmt([NotNull] GrammarParser.Else_stmtContext context)
        {
            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;
            base.EnterElse_stmt(context);
        }

        public override void ExitElse_stmt([NotNull] GrammarParser.Else_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitElse_stmt(context);
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

        private bool VarDeclLookup(string expression)
        {
            return currentScope.SymbolTable.Any(x => x.Key == expression);
        }
        

    }
}
