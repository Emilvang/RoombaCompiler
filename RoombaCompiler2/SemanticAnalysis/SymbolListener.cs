using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using RoombaCompiler2.SemanticAnalysis.Models;
using RoombaCompiler2.SemanticAnalysis.Utils;

namespace RoombaCompiler2.SemanticAnalysis
{
    public class SymbolListener : GrammarBaseListener
    {
        public SymbolTable SymbolTable = new SymbolTable();
        public ICollection<string> Errors = new HashSet<string>();
        private IDictionary<string, string> DeclaredMethods = new Dictionary<string, string>();

        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context) => EnterScopeAndSetType(EScopeType.Program);

        public override void ExitProgram([NotNull] GrammarParser.ProgramContext context) => SymbolTable.ExitScope();

        public override void EnterIf_stmt([NotNull] GrammarParser.If_stmtContext context) => EnterScopeAndSetType(EScopeType.Conditional);

        public override void ExitIf_stmt([NotNull] GrammarParser.If_stmtContext context) => SymbolTable.ExitScope();

        public override void EnterElse_stmt([NotNull] GrammarParser.Else_stmtContext context) => EnterScopeAndSetType(EScopeType.Conditional);

        public override void ExitElse_stmt([NotNull] GrammarParser.Else_stmtContext context) => SymbolTable.ExitScope();

        public override void EnterElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context) => EnterScopeAndSetType(EScopeType.Conditional);

        public override void ExitElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context) => SymbolTable.ExitScope();

        public override void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            var methodType = context.GetChild(0).ToStringTree();
            var methodName = context.GetChild(1).ToStringTree();

            if (!DeclaredMethods.ContainsKey(methodName))
            {
                DeclaredMethods.Add(methodName, methodType);
            }
            else
            {
                Errors.Add($"Method with name: {methodName} has already been declared.");
            }

            EnterScopeAndSetType($"{EScopeType.Method} [{methodType}] [{methodName}]");
        }

        public override void ExitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context) => SymbolTable.ExitScope();

        // TODO: Check Parameters
        public override void EnterIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            EnterScopeAndSetType(EScopeType.Loop);

            if (context.FOR() != null)
            {
                var variableName = context.IDENTIFIER().GetText();

                TryAddVariableToSymbolTable(variableName, EValueType.Integer);
            }
        }

        private void TryAddVariableToSymbolTable(string variableName, EValueType variableType)
        {
            if (SymbolTable.Lookup(variableName) != null)
            {
                Errors.Add($"Variable with name: {variableName} and type: {variableType} has already been declared.");
                return; // We cannot put the same variable name in the dictionary;
            }

            SymbolTable.Put(variableName, new Record(variableName, variableType));
        }

        public override void ExitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context) => SymbolTable.ExitScope();

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var variableName = context.GetChild(1).ToStringTree();
            var variableType = context.GetChild(0).ToStringTree();

            TryAddVariableToSymbolTable(variableName, variableType.GetVariableType());
        }

        public override void EnterNum_expr([NotNull] GrammarParser.Num_exprContext context) => ReportUndeclaredVariables(context);

        public override void EnterLogic_expr([NotNull] GrammarParser.Logic_exprContext context) => ReportUndeclaredVariables(context);

        private void ReportUndeclaredVariables(ParserRuleContext context)
        {
            if (context.children == null || !context.children.Any())
            {
                return; // Nothing to check the context doesn't have any children
            }

            foreach (var child in context.children.Where(x => x.GetType() == typeof(GrammarParser.Var_exprContext)))
            {
                var variableName = child.GetText();

                if (SymbolTable.Lookup(variableName) == null)
                {
                    Errors.Add($"Use of undeclared variable in {context.GetType()} with name: {variableName}");
                }
            }
        }

        private void EnterScopeAndSetType(EScopeType scopeType) => EnterScopeAndSetType(scopeType.ToString());

        private void EnterScopeAndSetType(string scopeType)
        {
            SymbolTable.EnterScope();
            SymbolTable.SetScopeType(scopeType);
        }
    }
}
