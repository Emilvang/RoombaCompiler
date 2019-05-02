// Generated from Grammar.g4 by ANTLR 4.7.2
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link GrammarParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface GrammarVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link GrammarParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(GrammarParser.ProgramContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#stmts}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStmts(GrammarParser.StmtsContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStmt(GrammarParser.StmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#var_decl}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVar_decl(GrammarParser.Var_declContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#cond_stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCond_stmt(GrammarParser.Cond_stmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#if_stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIf_stmt(GrammarParser.If_stmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#elseif_stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitElseif_stmt(GrammarParser.Elseif_stmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#else_stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitElse_stmt(GrammarParser.Else_stmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#parameter_decl}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameter_decl(GrammarParser.Parameter_declContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#func_stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunc_stmt(GrammarParser.Func_stmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#func_expr}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunc_expr(GrammarParser.Func_exprContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#iter_stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIter_stmt(GrammarParser.Iter_stmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#print}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPrint(GrammarParser.PrintContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#expr}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpr(GrammarParser.ExprContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#var_expr}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVar_expr(GrammarParser.Var_exprContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#num_expr}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNum_expr(GrammarParser.Num_exprContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#logic_expr}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogic_expr(GrammarParser.Logic_exprContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#var_stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVar_stmt(GrammarParser.Var_stmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#return_stmt}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitReturn_stmt(GrammarParser.Return_stmtContext ctx);
	/**
	 * Visit a parse tree produced by {@link GrammarParser#compileUnit}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompileUnit(GrammarParser.CompileUnitContext ctx);
}