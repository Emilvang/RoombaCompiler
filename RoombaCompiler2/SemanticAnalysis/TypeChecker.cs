﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using RoombaCompiler2.SemanticAnalysis.Models;
using RoombaCompiler2.SemanticAnalysis.Utils;
using System;
using System.Collections.Generic;

namespace RoombaCompiler2.SemanticAnalysis
{
    public class TypeChecker : GrammarBaseVisitor<EValueType?>
    {
        private readonly SymbolTable _symbolTable;
        private readonly ICollection<string> Errors = new HashSet<string>();

        public TypeChecker(SymbolTable symbolTable)
        {
            _symbolTable = symbolTable ?? throw new ArgumentNullException(nameof(symbolTable));
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

            if (methodType != returnType)
            {
                Errors.Add($"Found a Type missmatch in the method: {methodName} declaration. Method type is {methodType} and return type is {returnType}");
            }

            base.Visit(context.stmts());

            _symbolTable.ExitScope();

            return methodType;
        }

        public override EValueType? VisitReturn_stmt([NotNull] GrammarParser.Return_stmtContext context) => base.Visit(context.expr());

        public override EValueType? VisitIf_stmt([NotNull] GrammarParser.If_stmtContext context) => VisitContextAndScope(context.stmts());

        public override EValueType? VisitElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context) => VisitContextAndScope(context.stmts());

        public override EValueType? VisitElse_stmt([NotNull] GrammarParser.Else_stmtContext context) => VisitContextAndScope(context.stmts());

        public override EValueType? VisitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context) => VisitContextAndScope(context.stmts());

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

                // TODO: Allow mixing of ints and floats?
                if (leftValueType != rightValueType)
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
                else if (!value.IsBoolLiteral())
                {
                    Errors.Add($"Value: {value} cannot be used in a logical expression");
                }
            }
            else
            {
                var leftValueType = base.Visit(context.GetChild(0));
                var rightValueType = base.Visit(context.GetChild(2));

                if (leftValueType != rightValueType)
                {
                    Errors.Add($"Found a type error. Cannot mix {leftValueType} and {rightValueType}");
                }
            }

            return EValueType.Boolean;
        }

        public override EValueType? VisitVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var declaredType = context.GetChild(0).GetText().GetVariableType();
            var variableName = context.GetChild(1).GetText();
            var expressionType = base.Visit(context.GetChild(3));

            if (declaredType != expressionType)
            {
                Errors.Add($"Expression does not match declared type in the declaration of variable: {variableName}");
            }

            return declaredType;
        }

        public override EValueType? VisitVar_expr([NotNull] GrammarParser.Var_exprContext context) => GetVariableTypeFromSymbolTable(context.GetChild(0).GetText());

        private EValueType? GetVariableTypeFromSymbolTable(string variableName) => _symbolTable.Lookup(variableName)?.Type;

        private EValueType? VisitContextAndScope(ParserRuleContext context)
        {
            _symbolTable.EnterScope();

            var result = base.Visit(context);

            _symbolTable.ExitScope();

            return result;
        }
    }
}
