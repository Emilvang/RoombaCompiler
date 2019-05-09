using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using RoombaCompiler2.SemanticAnalysis.Models;
using RoombaCompiler2.SemanticAnalysis.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;

namespace RoombaCompiler2.SemanticAnalysis
{
    public class TypeChecker : GrammarBaseVisitor<EValueType?>
    {
        public readonly ICollection<string> Errors = new HashSet<string>();

        private readonly SymbolTable _symbolTable;
        private readonly IReadOnlyDictionary<string, MethodRecord> _methodsTable;

        public TypeChecker(SymbolTable symbolTable, IReadOnlyDictionary<string, MethodRecord> methodsTable)
        {
            _symbolTable = symbolTable ?? throw new ArgumentNullException(nameof(symbolTable));
            _methodsTable = methodsTable ?? throw new ArgumentNullException(nameof(methodsTable));
        }

        public override EValueType? VisitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            _symbolTable.EnterScope();

            base.VisitProgram(context);

            _symbolTable.ExitScope();

            return null;
        }

        public override EValueType? VisitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            _symbolTable.EnterScope();

            var methodType = context.GetChild(0).GetText().GetVariableType();
            var methodName = context.GetChild(1).GetText();
            var returnType = base.Visit(context.GetChild(context.ChildCount - 2));

            if (methodType != EValueType.Void && methodType != returnType)
            {
                Errors.Add($"Found a Type missmatch in the method: {methodName} declaration. Method type is {methodType} and return type is {returnType}");
            }

            base.Visit(context.stmts());

            _symbolTable.ExitScope();

            return methodType;
        }

        public override EValueType? VisitReturn_stmt([NotNull] GrammarParser.Return_stmtContext context) => base.Visit(context.expr());

        public override EValueType? VisitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            if (context.WHILE() != null)
            {
                base.Visit(context.logic_expr());
            }

            return VisitContextAndOpenScope(context.stmts());
        }

        public override EValueType? VisitIf_stmt([NotNull] GrammarParser.If_stmtContext context) => VisitConditionalWithBodyAndScope(context.stmts(), context.logic_expr());

        public override EValueType? VisitElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context) => VisitConditionalWithBodyAndScope(context.stmts(), context.logic_expr());

        public override EValueType? VisitElse_stmt([NotNull] GrammarParser.Else_stmtContext context) => VisitContextAndOpenScope(context.stmts());

        public override EValueType? VisitNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {
            if (context.ChildCount == 1)
            {
                var valueType = context.GetChild(0).GetType();
                var value = context.GetChild(0).GetText();

                if (valueType == typeof(GrammarParser.Var_exprContext))
                {
                    var variableType = GetVariableTypeFromSymbolTable(value);
                    if (variableType != EValueType.Integer && variableType != EValueType.Float)
                    {
                        Errors.Add($"Variable with name: {value} and type: {variableType} cannot be used in a numerical expression.");
                    }

                    return variableType;
                }
                else if (valueType == typeof(GrammarParser.Func_exprContext))
                {
                    return base.Visit(context.GetChild(0));
                }
                else if (value.IsFloat())
                {
                    return EValueType.Float;
                }
                else if (value.IsInteger())
                {
                    return EValueType.Integer;
                }
                else
                {
                    Errors.Add($"Cannot use the value: {value} in a numerical expression");
                }
            }
            else
            {
                var leftValueType = base.Visit(context.GetChild(0));
                var rightValueType = base.Visit(context.GetChild(2));

                if ((leftValueType == EValueType.Integer && rightValueType == EValueType.Float) ||
                    (leftValueType == EValueType.Float && rightValueType == EValueType.Integer))
                {
                    return EValueType.Float; // If a Float is found in the expression the expression automatically becomes float expression
                }
                else if (leftValueType != rightValueType)
                {
                    Errors.Add($"Found a type error. Cannot mix {leftValueType} and {rightValueType}");
                }

                return leftValueType;
            }

            return null;
        }

        public override EValueType? VisitLogic_expr([NotNull] GrammarParser.Logic_exprContext context)
        {
            if (context.ChildCount == 1)
            {
                var valueType = context.GetChild(0).GetType();
                var value = context.GetChild(0).GetText();

                if (valueType == typeof(GrammarParser.Var_exprContext))
                {
                    var variableType = GetVariableTypeFromSymbolTable(value);
                    if (variableType != EValueType.Boolean)
                    {
                        Errors.Add($"Variable with name: {value} and type: {variableType} cannot be used in a logical expression.");
                    }
                }
                else if (valueType == typeof(GrammarParser.Func_exprContext))
                {
                    var methodType = base.Visit(context.GetChild(0));
                    if (methodType != EValueType.Boolean)
                    {
                        Errors.Add($"Cannot use method of type: {methodType} in a logical expression");
                    }
                }
                else if (!value.IsBoolLiteral())
                {
                    Errors.Add($"Value: {value} cannot be used in a logical expression");
                }
            }
            else
            {
                var leftValueType = base.Visit(context.GetChild(0));
                var rightValueType = base.Visit(context.GetChild(2));

                if (leftValueType.HasValue && leftValueType.Value.IsInteger() && rightValueType.HasValue && rightValueType.Value.IsInteger())
                {
                    // Integers and floats can be compared
                }
                else if (leftValueType != rightValueType)
                {
                    Errors.Add($"Found a type error. Cannot mix {leftValueType} and {rightValueType}");
                }
            }

            return EValueType.Boolean;
        }

        public override EValueType? VisitVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            var variableName = context.IDENTIFIER().GetText();
            var variableRecord = _symbolTable.Lookup(variableName);

            if (variableRecord == null)
            {
                /// Cannot check the type of a variable that does not exist
                /// There is an error that has been caught by the <see cref="SymbolListener"/>
                return null;
            }

            var expressionType = base.Visit(context.GetChild(2));

            CheckForNumberAssignmentError(variableRecord.Type, expressionType, variableName, "assignment");

            return null;
        }

        public override EValueType? VisitExpr([NotNull] GrammarParser.ExprContext context) => base.Visit(context.children.Single(x => x.GetType() != typeof(TerminalNodeImpl)));

        public override EValueType? VisitVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var declaredType = context.GetChild(0).GetText().GetVariableType();
            var variableName = context.GetChild(1).GetText();
            var expressionType = base.Visit(context.GetChild(3));

            CheckForNumberAssignmentError(declaredType, expressionType, variableName, "declaration");

            return null;
        }

        public override EValueType? VisitFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            var methodName = context.IDENTIFIER().GetText();
            if (!_methodsTable.ContainsKey(methodName))
            {
                Errors.Add($"Method with name: {methodName} does not exist.");
                return null;
            }

            var method = _methodsTable[methodName];

            // Its a hack when calling a function with no parameters
            if (method.Parameters.Count == 0 && context.children.SingleOrDefault(x => x.GetType() == typeof(GrammarParser.ExprContext))?.GetChild(0)?.GetChild(0) == null)
            {
                return method.ReturnType;
            }
            else if (method.Parameters.Count != context.children.Count(x => x.GetType() == typeof(GrammarParser.ExprContext)))
            {
                Errors.Add($"There is a different number of parameters when invoking the method: {methodName}");
                return null;
            }

            var index = 0;

            foreach (var methodParameter in context.children.Where(x => x.GetType() == typeof(GrammarParser.ExprContext)))
            {
                var actualMethodParameterType = base.Visit(methodParameter);
                var declaredMethodParameterType = method.Parameters.ElementAt(index).Value; // Out of range dictionary

                if (declaredMethodParameterType == EValueType.Float && actualMethodParameterType == EValueType.Integer)
                {
                    // It is okay to pass an int into a float
                }
                else if (actualMethodParameterType != declaredMethodParameterType)
                {
                    Errors.Add($"Parameter types for the method: {methodName} do not match with declaration");
                    return null;
                }

                index++;
            }

            return method.ReturnType;
        }

        public override EValueType? VisitVar_expr([NotNull] GrammarParser.Var_exprContext context) => GetVariableTypeFromSymbolTable(context.GetChild(0).GetText());

        private EValueType? GetVariableTypeFromSymbolTable(string variableName) => _symbolTable.Lookup(variableName)?.Type;

        private EValueType? VisitConditionalWithBodyAndScope(ParserRuleContext body, GrammarParser.Logic_exprContext condition)
        {
            base.Visit(condition);

            return VisitContextAndOpenScope(body);
        }

        private EValueType? VisitContextAndOpenScope(ParserRuleContext context)
        {
            _symbolTable.EnterScope();

            var result = base.Visit(context);

            _symbolTable.ExitScope();

            return result;
        }

        private void CheckForNumberAssignmentError(EValueType declaredType, EValueType? expressionType, string variableName, string action)
        {
            if (declaredType == EValueType.Float && expressionType == EValueType.Integer)
            {
                // No Errors skip it
            }
            else if (declaredType != expressionType)
            {
                Errors.Add($"Expression does not match declared type in the {action} of variable: {variableName}");
            }
        }
    }
}
