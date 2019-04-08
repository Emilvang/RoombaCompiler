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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IGrammarListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class GrammarBaseListener : IGrammarListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] GrammarParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] GrammarParser.ProgramContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stmts"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmts([NotNull] GrammarParser.StmtsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stmts"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmts([NotNull] GrammarParser.StmtsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmt([NotNull] GrammarParser.StmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmt([NotNull] GrammarParser.StmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.var_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVar_stmt([NotNull] GrammarParser.Var_stmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.var_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVar_stmt([NotNull] GrammarParser.Var_stmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.var_decl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVar_decl([NotNull] GrammarParser.Var_declContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.var_decl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVar_decl([NotNull] GrammarParser.Var_declContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.cond_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCond_stmt([NotNull] GrammarParser.Cond_stmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.cond_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.func_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.func_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.function_expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction_expr([NotNull] GrammarParser.Function_exprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.function_expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction_expr([NotNull] GrammarParser.Function_exprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.iter_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIter_stmt([NotNull] GrammarParser.Iter_stmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.iter_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.print"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrint([NotNull] GrammarParser.PrintContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.print"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrint([NotNull] GrammarParser.PrintContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpr([NotNull] GrammarParser.ExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpr([NotNull] GrammarParser.ExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.var_expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVar_expr([NotNull] GrammarParser.Var_exprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.var_expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVar_expr([NotNull] GrammarParser.Var_exprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.num_expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNum_expr([NotNull] GrammarParser.Num_exprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.num_expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNum_expr([NotNull] GrammarParser.Num_exprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.logic_expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogic_expr([NotNull] GrammarParser.Logic_exprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.logic_expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogic_expr([NotNull] GrammarParser.Logic_exprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.return_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturn_stmt([NotNull] GrammarParser.Return_stmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.return_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturn_stmt([NotNull] GrammarParser.Return_stmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.compileUnit"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompileUnit([NotNull] GrammarParser.CompileUnitContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.compileUnit"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompileUnit([NotNull] GrammarParser.CompileUnitContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
