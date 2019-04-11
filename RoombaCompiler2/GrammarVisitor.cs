//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="GrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] GrammarParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.stmts"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmts([NotNull] GrammarParser.StmtsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmt([NotNull] GrammarParser.StmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.var_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVar_stmt([NotNull] GrammarParser.Var_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.var_decl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVar_decl([NotNull] GrammarParser.Var_declContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.cond_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.func_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.func_expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc_expr([NotNull] GrammarParser.Func_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.iter_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.print"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrint([NotNull] GrammarParser.PrintContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] GrammarParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.var_expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVar_expr([NotNull] GrammarParser.Var_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.num_expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNum_expr([NotNull] GrammarParser.Num_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.logic_expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogic_expr([NotNull] GrammarParser.Logic_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.return_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturn_stmt([NotNull] GrammarParser.Return_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompileUnit([NotNull] GrammarParser.CompileUnitContext context);
}
