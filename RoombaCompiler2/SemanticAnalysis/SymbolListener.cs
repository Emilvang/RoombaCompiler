using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using RoombaCompiler2.SemanticAnalysis.Models;
using RoombaCompiler2.SemanticAnalysis.Utils;

namespace RoombaCompiler2.SemanticAnalysis
{
    public class SymbolListener : GrammarBaseListener
    {
        public SymbolTable SymbolTable = new SymbolTable();
        public ICollection<string> Errors = new HashSet<string>();
        public IDictionary<string, MethodRecord> DeclaredMethods = new Dictionary<string, MethodRecord>();

        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context)
        {
            EnterScopeAndSetType(EScopeType.Program);
            PopulateWithBuiltInFunctions();
        }

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

        public override void EnterIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            EnterScopeAndSetType(EScopeType.Loop);

            if (context.FOR() != null)
            {
                var variableName = context.IDENTIFIER().GetText();

                TryAddVariableToSymbolTable(variableName, EValueType.Integer);
            }
        }

        public override void ExitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context) => SymbolTable.ExitScope();

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var variableName = context.GetChild(1).ToStringTree();
            var variableType = context.GetChild(0).ToStringTree();

            TryAddVariableToSymbolTable(variableName, variableType.GetVariableType());
        }

        public override void EnterVar_expr([NotNull] GrammarParser.Var_exprContext context) => ReportUndeclaredVariable(context.IDENTIFIER());

        public override void EnterNum_expr([NotNull] GrammarParser.Num_exprContext context) => ReportUndeclaredVariablesAndMethodsFromContext(context);

        public override void EnterFunc_expr([NotNull] GrammarParser.Func_exprContext context) => ReportUndeclaredMethod(context.IDENTIFIER());

        public override void EnterLogic_expr([NotNull] GrammarParser.Logic_exprContext context) => ReportUndeclaredVariablesAndMethodsFromContext(context);

        public override void EnterVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            var variableName = context.IDENTIFIER().GetText();

            if (SymbolTable.Lookup(variableName) == null)
            {
                Errors.Add($"Cannot assign to a variable with name: {variableName} that does not exist");
            }
        }

        private void ReportUndeclaredVariablesAndMethodsFromContext(ParserRuleContext context)
        {
            if (context.children == null || !context.children.Any())
            {
                return; // Nothing to check the context doesn't have any children
            }

            foreach (var child in context.children)
            {
                if (child.GetType() == typeof(GrammarParser.Var_exprContext))
                {
                    var variable = child as GrammarParser.Var_exprContext;

                    ReportUndeclaredVariable(variable.IDENTIFIER());
                }
                else if (child.GetType() == typeof(GrammarParser.Func_exprContext))
                {
                    var method = child as GrammarParser.Func_exprContext;

                    ReportUndeclaredMethod(method.IDENTIFIER());
                }
            }
        }

        private void ReportUndeclaredVariable(ITerminalNode variable)
        {
            var variableName = variable.GetText();

            if (SymbolTable.Lookup(variableName) == null)
            {
                Errors.Add($"Use of undeclared variable with name: {variableName}");
            }
        }

        private void ReportUndeclaredMethod(ITerminalNode method)
        {
            var methodName = method.GetText();

            if (!DeclaredMethods.ContainsKey(methodName))
            {
                Errors.Add($"Use of undeclared function with name: {methodName}");
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

        private void EnterScopeAndSetType(EScopeType scopeType) => EnterScopeAndSetType(scopeType.ToString());

        private void EnterScopeAndSetType(string scopeType)
        {
            SymbolTable.EnterScope();
            SymbolTable.SetScopeType(scopeType);
        }

        public void PrintErrors()
        {
            foreach (var Error in Errors)
            {
                System.Console.WriteLine(Error);
            }
        }

        private void PopulateWithBuiltInFunctions()
        {
            //Solution to built in procedures
            //Needs to be called somewhere.

            //Turn
            var turnDictionary = new Dictionary<string, EValueType>();
            turnDictionary.Add("degrees", EValueType.Integer);

            var turnRecord = new MethodRecord("Turn", EValueType.Void, turnDictionary);
            DeclaredMethods.Add("Turn", turnRecord);

            //Stop
            var stopDictionary = new Dictionary<string, EValueType>();
            var stopRecord = new MethodRecord("Stop", EValueType.Void, stopDictionary);
            DeclaredMethods.Add("Stop", stopRecord);

            //Pause
            var pauseDictionary = new Dictionary<string, EValueType>();
            pauseDictionary.Add("Seconds", EValueType.Float);
            var pauseRecord = new MethodRecord("Pause", EValueType.Void, pauseDictionary);
            DeclaredMethods.Add("Pause", pauseRecord);

            //DriveStraight //Rename in project instead of introducing function overloading
            var driveStraightDictionary = new Dictionary<string, EValueType>();
            driveStraightDictionary.Add("Speed", EValueType.Integer);
            var driveStraightRecord = new MethodRecord("DriveStraight", EValueType.Void, driveStraightDictionary);
            DeclaredMethods.Add("DriveStraight", driveStraightRecord);

            //Drive
            var driveDictionary = new Dictionary<string, EValueType>();
            driveDictionary.Add("Speed", EValueType.Integer);
            driveDictionary.Add("Distance", EValueType.Integer);
            var driveRecord = new MethodRecord("Drive", EValueType.Void, driveDictionary);
            DeclaredMethods.Add("Drive", driveRecord);

            //CoverCircle
            var coverCircleDictionary = new Dictionary<string, EValueType>();
            coverCircleDictionary.Add("Radius", EValueType.Integer);
            var coverCircleRecord = new MethodRecord("CoverCircle", EValueType.Void, coverCircleDictionary);
            DeclaredMethods.Add("CoverCircle", coverCircleRecord);

            //CoverRectangle
            var coverRectangleDictionary = new Dictionary<string, EValueType>();
            coverRectangleDictionary.Add("Width", EValueType.Integer);
            coverRectangleDictionary.Add("Height", EValueType.Integer);
            var coverRectangleRecord = new MethodRecord("CoverRectangle", EValueType.Void, coverRectangleDictionary);
            DeclaredMethods.Add("CoverRectangle", coverRectangleRecord);

            //Dock
            var dockDictionary = new Dictionary<string, EValueType>();
            var dockRecord = new MethodRecord("Dock", EValueType.Void, dockDictionary);
            DeclaredMethods.Add("Dock", dockRecord);
        }
    }
}
