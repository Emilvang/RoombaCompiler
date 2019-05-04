using Antlr4.Runtime.Misc;
using RoombaCompiler2.SemanticAnalysis.Models;
using RoombaCompiler2.SemanticAnalysis.Utils;
using System;
using System.Collections.Generic;

namespace RoombaCompiler2.SemanticAnalysis
{
    public class TypeChecker : GrammarBaseVisitor<EVariableType>
    {
        private readonly SymbolTable _symbolTable;
        private readonly ICollection<string> Errors = new List<string>();

        public TypeChecker(SymbolTable symbolTable)
        {
            _symbolTable = symbolTable ?? throw new ArgumentNullException(nameof(symbolTable));
        }

        public override EVariableType VisitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            _symbolTable.EnterScope();

            var result = base.VisitProgram(context);

            _symbolTable.ExitScope();

            return result;
        }

        public override EVariableType VisitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            _symbolTable.EnterScope();

            //var result = base.VisitFunc_stmt(context);
            var methodType = context.GetChild(0).GetText().GetVariableType();
            var methodName = context.GetChild(1).GetText();
            var returnType = base.Visit(context.GetChild(context.ChildCount - 2));

            if (methodType != returnType)
            {
                Errors.Add($"Found a Type missmatch in the {methodName}. Method type is {methodType} and return type is {returnType}");
            }

            base.Visit(context.stmts());

            _symbolTable.ExitScope();

            return returnType;
        }

        public override EVariableType VisitReturn_stmt([NotNull] GrammarParser.Return_stmtContext context)
        {
            return base.Visit(context.GetChild(1));
        }

        public override EVariableType VisitNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {
            if (context.ChildCount == 1)
            {
                var value = context.GetChild(0);

                if (value.GetType() == typeof(GrammarParser.Var_exprContext))
                {
                    return _symbolTable.Lookup(value.GetText()).Type;
                }
                else if (value.GetText().IsFloat())
                {
                    return EVariableType.Float;
                }
                else if (value.GetText().IsInteger())
                {
                    return EVariableType.Integer;
                }
                else
                {
                    throw new NotImplementedException("Unrecognized type");
                }
            }
            else
            {
                var leftValueType = base.Visit(context.GetChild(0));
                var rightValueType = base.Visit(context.GetChild(2));

                // TODO: Allow mixing of ints and floats?
                if (leftValueType != rightValueType)
                {
                    Errors.Add($"Found a type error. Cannot mix {leftValueType} amd {rightValueType}");
                    return EVariableType.Unknown;
                }

                return leftValueType;
            }
        }

        public override EVariableType VisitLogic_expr([NotNull] GrammarParser.Logic_exprContext context)
        {
            return base.VisitLogic_expr(context);
        }

        public override EVariableType VisitStmts([NotNull] GrammarParser.StmtsContext context)
        {
            return base.VisitStmts(context);
        }

        public override EVariableType VisitVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            var declaredType = context.GetChild(0).GetText().GetVariableType();
            var expressionType = base.Visit(context.GetChild(2));

            if (declaredType != expressionType)
            {
                Errors.Add($"Expression does not match declared type");
                return EVariableType.Unknown;
            }

            return declaredType;
        }
    }
}
