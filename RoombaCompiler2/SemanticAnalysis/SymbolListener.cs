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
        public IDictionary<string, MethodRecord> DeclaredMethods = new Dictionary<string, MethodRecord>();

        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context) => EnterScopeAndSetType(EScopeType.Program);

        public override void ExitProgram([NotNull] GrammarParser.ProgramContext context) => SymbolTable.ExitScope();

        public override void EnterIf_stmt([NotNull] GrammarParser.If_stmtContext context) => EnterScopeAndSetType(EScopeType.Conditional);

        public override void ExitIf_stmt([NotNull] GrammarParser.If_stmtContext context) => SymbolTable.ExitScope();

        public override void EnterElse_stmt([NotNull] GrammarParser.Else_stmtContext context) => EnterScopeAndSetType(EScopeType.Conditional);

        public override void ExitElse_stmt([NotNull] GrammarParser.Else_stmtContext context) => SymbolTable.ExitScope();

        public override void EnterElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context) => EnterScopeAndSetType(EScopeType.Conditional);

        public override void ExitElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context) => SymbolTable.ExitScope();

        private IReadOnlyDictionary<string, EValueType> GetParameters(IEnumerable<GrammarParser.Parameter_declContext> parametersContexts, string functionName)
        {
            var result = new Dictionary<string, EValueType>();

            if (parametersContexts == null || !parametersContexts.Any())
            {
                return result;
            }

            foreach (var context in parametersContexts)
            {
                if (context.ChildCount == 0)
                {
                    continue;
                }

                var variableType = context.GetChild(0).GetText();
                var variableName = context.GetChild(1).GetText();

                if (result.ContainsKey(variableName))
                {
                    Errors.Add($"Function declaration with name: {functionName} already contains a paramater with the name: {variableName}");
                    return result;
                }
                else
                {
                    result.Add(variableName, variableType.GetVariableType());
                }
            }

            return result;
        }

        public override void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            var methodType = context.GetChild(0).ToStringTree();
            var methodName = context.GetChild(1).ToStringTree();

            if (!DeclaredMethods.ContainsKey(methodName))
            {
                DeclaredMethods.Add(methodName, new MethodRecord(methodName, methodType.GetVariableType(), GetParameters(context.parameter_decl(), methodName)));
            }
            else
            {
                Errors.Add($"Method with name: {methodName} has already been declared.");
            }

            EnterScopeAndSetType($"{EScopeType.Method} [{methodType}] [{methodName}]");
        }

        public override void EnterParameter_decl([NotNull] GrammarParser.Parameter_declContext context) => 
            TryAddVariableToSymbolTable(context.GetChild(1).GetText(), context.GetChild(0).GetText().GetVariableType());

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

            SymbolTable.Put(variableName, new VariableRecord(variableName, variableType));
        }

        public override void ExitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context) => SymbolTable.ExitScope();

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var variableName = context.GetChild(1).ToStringTree();
            var variableType = context.GetChild(0).ToStringTree();

            TryAddVariableToSymbolTable(variableName, variableType.GetVariableType());
        }

        public override void EnterNum_expr([NotNull] GrammarParser.Num_exprContext context) => ReportUndeclaredVariablesAndMethods(context);

        public override void EnterLogic_expr([NotNull] GrammarParser.Logic_exprContext context) => ReportUndeclaredVariablesAndMethods(context);

        private void ReportUndeclaredVariablesAndMethods(ParserRuleContext context)
        {
            if (context.children == null || !context.children.Any())
            {
                return; // Nothing to check the context doesn't have any children
            }

            foreach (var child in context.children)
            {
                if (child.GetType() == typeof(GrammarParser.Var_exprContext))
                {
                    var variableName = child.GetText();

                    if (SymbolTable.Lookup(variableName) == null)
                    {
                        Errors.Add($"Use of undeclared variable in {context.GetType()} with name: {variableName}");
                    }
                }
                else if (child.GetType() == typeof(GrammarParser.Func_exprContext))
                {
                    var function = child as GrammarParser.Func_exprContext;
                    var functionName = function.IDENTIFIER().GetText();

                    if (!DeclaredMethods.ContainsKey(functionName))
                    {
                        Errors.Add($"Use of undeclared function with name: {functionName}");
                    }

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
