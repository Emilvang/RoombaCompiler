using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
    class Listener : GrammarBaseListener
    {

        public Stack<Scope> ScopeStack { get; set; }
        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context)
        {
            Console.WriteLine("EnterProgram");
            ScopeStack = new Stack<Scope>();
            ScopeStack.Push(new Scope());
            base.EnterProgram(context);
        }
        public override void ExitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            ScopeStack.Pop();
            Console.WriteLine("ExitProgram");
            base.ExitProgram(context);
        }
        public override void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            Console.WriteLine("Enterfunc");
            var currentScope = new Scope(ScopeStack.Peek());
            ScopeStack.Push(currentScope);
            base.EnterFunc_stmt(context);
        }
        public override void ExitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            Console.WriteLine("Exitfunc");
            ScopeStack.Pop();
            base.ExitFunc_stmt(context);
        }
        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            Console.WriteLine("Var_decl" + context.IDENTIFIER().ToString() + " type: " + context.GetChild(0).GetText());
            var currentScope = ScopeStack.Peek();
            currentScope.Members.Add(new Symbol(context.GetChild(1).GetText(), context.GetChild(0).GetText()));
            ChangeCurrentScope(currentScope);

            base.EnterVar_decl(context);
        }
        public override void EnterParameter_decl([NotNull] GrammarParser.Parameter_declContext context)
        {
            var currentScope = ScopeStack.Peek();
            currentScope.Members.Add(new Symbol(context.GetChild(1).GetText(), context.GetChild(0).GetText()));
            base.EnterParameter_decl(context);
        }

        //To be called when a new variable/function is added to the scope
        public void ChangeCurrentScope (Scope scope)
        {
            ScopeStack.Pop();
            ScopeStack.Push(scope);
        }
    }
}
