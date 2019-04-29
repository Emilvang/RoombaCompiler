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

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var variableName = context.GetChild(1).GetText();
            var type = context.GetChild(0).GetText().ToLower();

            for (int i = 4; i < context.ChildCount; i += 2)
            {
                var exprType = GetType(context.GetChild(i).GetText());
                if (exprType != type || !(exprType == "int" && type == "float"))
                {
                    throw new Exception("Type mismatch");
                }
            }
            if (!LookUpScope(variableName))
            {
                currentScope.SymbolTable.Add(new Symbol(variableName, type));
            }
            else
            {
                throw new Exception("Variable already exists in local or parent scopes!");
            }

            base.EnterVar_decl(context);
        }

        public override void EnterVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            var lhs = GetType(context.GetChild(0).GetText());
            string rhs;
            int ii = context.GetChild(2).ChildCount;
            var vvv = context.GetChild(2);
            if (context.GetChild(2).ChildCount > 1)
            {
                for (int i = 0; i < context.GetChild(2).ChildCount; i += 2)
                {
                    rhs = context.GetChild(2).GetChild(i).GetText();
                    if (lhs != rhs && !(lhs == "float" && rhs == "int"))
                        throw new Exception("Type mismatch");
                }
            }
            else
            {
                rhs = GetType(context.GetChild(2).GetText());
                if (lhs != rhs && !(lhs == "float" && rhs == "int"))
                    throw new Exception("Type mismatch");
            }
            base.EnterVar_stmt(context);

        }

        public override void EnterNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {      

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
            
            base.EnterFunc_expr(context);
        }
        public override void ExitFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {            
            base.ExitFunc_expr(context);
        }
        //Needs variable dec. for parametres
        public override void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            var funcName = context.GetChild(1).GetText();
            var funcType = context.GetChild(0).GetText();
            ScopeNode LocalScope = new ScopeNode();
            Scopes.Add(LocalScope);
            LocalScope.Parent = currentScope;
            currentScope = LocalScope;


            //3 because here the arguments begin.
            int count2 = 3;
            //Probably needs an escape or exception thrown somehow if the programmer makes an error. What happens if the programmer forgets a comma?
            //Cant handle no arguments.
            var parameters = new List<Symbol>();
            while (true)
            {
                try
                {
                    var variableName = context.GetChild(count2).GetChild(1).GetText();
                    var variableType = context.GetChild(count2 - 1).GetText();

                    if (!LookUpScope(variableName))
                    {
                        var parameter = new Symbol(variableName, variableType);
                        currentScope.SymbolTable.Add(parameter);

                        //needed for when function is called to check types of arguments
                        parameters.Add(parameter);
                    }
                    else
                    {
                        throw new Exception("Variable already exists in local or parent scopes!");
                    }
                }
                catch
                {
                    break;
                }

                //null for now, because the variable doesn't have a value at this stage.
                //Might need other solution later. 

                //Checking if the next child is ')', meaning it has reached the end of the arguments. Break if so, else continue.
                if (context.GetChild(count2 + 1).GetText() == ")")
                {
                    //adds function to parent symbol table
                    var funcSymbol = new FunctionSymbol(funcName, funcType, parameters);
                    currentScope.Parent.SymbolTable.Add(funcSymbol);
                    break;
                }

                else count2 += 2;
            }
                       


            base.EnterFunc_stmt(context);
        }

        public override void ExitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            currentScope = currentScope.Parent;
            base.ExitFunc_stmt(context);
        }

        public override void EnterArithmetic_expr([NotNull] GrammarParser.Arithmetic_exprContext context)
        {
            Console.WriteLine("arith");
            base.EnterArithmetic_expr(context);
        }
        private string LookUpVarType (string expression)
        {
            ScopeNode Scope = currentScope;

            while (Scope != null)
            {
                if (Scope.SymbolTable.Any(x => x.Name == expression))
                {
                    return Scope.SymbolTable.FirstOrDefault(x => x.Name == expression).Type;
                }
                else
                {
                    Scope = Scope.Parent;
                }
            }

            throw new Exception("Variable " + expression + " is out of scope or not declared");
        }

        private bool LookUpScope(string expression)
        {
            ScopeNode Scope = currentScope;

            while (Scope != null)
            {
                if (Scope.SymbolTable.Any(x => x.Name == expression))
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

        private string GetType(string expression)
        {
            var expressions = SplitExpression(expression);
            
            if(expressions.Length > 1)
            {
                int bools = 0;
                int floats = 0;
                int ints = 0;
                foreach (var element in expressions)
                {
                    Console.WriteLine(element);
                    if (GetType(element) == "int")
                        ints++;
                    else if (GetType(element) == "float")
                        floats++;
                    else if (GetType(element) == "bool")
                        bools++;
                    Console.WriteLine(bools + " " + floats + " " + ints);
                    if (bools == 0 && ints >= 0 && floats > 0)
                        return "float";
                    else if (ints == expressions.Length)
                        return "int";
                    else if (bools == expressions.Length)
                        return "bool";
                }
                throw new Exception("Type mismatch on variable " + expression);
            }
            else
            {
                if (int.TryParse(expression, out var result))
                    return "int";
                else if (float.TryParse(expression, out var result2))
                    return "float";
                else if (bool.TryParse(expression, out var result3))
                    return "bool";
                else
                    return LookUpVarType(expression);
            }
        }

        private string[] SplitExpression(string expression)
        {
            string[] delimiters = { "*", "+", "/", "-", "<=", ">=", "<", ">", "!=", "==" };
            return expression.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
