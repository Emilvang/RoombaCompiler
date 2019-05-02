// Generated from Grammar.g4 by ANTLR 4.7.2
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link GrammarParser}.
 */
public interface GrammarListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link GrammarParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(GrammarParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(GrammarParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#stmts}.
	 * @param ctx the parse tree
	 */
	void enterStmts(GrammarParser.StmtsContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#stmts}.
	 * @param ctx the parse tree
	 */
	void exitStmts(GrammarParser.StmtsContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#stmt}.
	 * @param ctx the parse tree
	 */
	void enterStmt(GrammarParser.StmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#stmt}.
	 * @param ctx the parse tree
	 */
	void exitStmt(GrammarParser.StmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#var_decl}.
	 * @param ctx the parse tree
	 */
	void enterVar_decl(GrammarParser.Var_declContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#var_decl}.
	 * @param ctx the parse tree
	 */
	void exitVar_decl(GrammarParser.Var_declContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#cond_stmt}.
	 * @param ctx the parse tree
	 */
	void enterCond_stmt(GrammarParser.Cond_stmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#cond_stmt}.
	 * @param ctx the parse tree
	 */
	void exitCond_stmt(GrammarParser.Cond_stmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#if_stmt}.
	 * @param ctx the parse tree
	 */
	void enterIf_stmt(GrammarParser.If_stmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#if_stmt}.
	 * @param ctx the parse tree
	 */
	void exitIf_stmt(GrammarParser.If_stmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#elseif_stmt}.
	 * @param ctx the parse tree
	 */
	void enterElseif_stmt(GrammarParser.Elseif_stmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#elseif_stmt}.
	 * @param ctx the parse tree
	 */
	void exitElseif_stmt(GrammarParser.Elseif_stmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#else_stmt}.
	 * @param ctx the parse tree
	 */
	void enterElse_stmt(GrammarParser.Else_stmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#else_stmt}.
	 * @param ctx the parse tree
	 */
	void exitElse_stmt(GrammarParser.Else_stmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#parameter_decl}.
	 * @param ctx the parse tree
	 */
	void enterParameter_decl(GrammarParser.Parameter_declContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#parameter_decl}.
	 * @param ctx the parse tree
	 */
	void exitParameter_decl(GrammarParser.Parameter_declContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#func_stmt}.
	 * @param ctx the parse tree
	 */
	void enterFunc_stmt(GrammarParser.Func_stmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#func_stmt}.
	 * @param ctx the parse tree
	 */
	void exitFunc_stmt(GrammarParser.Func_stmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#func_expr}.
	 * @param ctx the parse tree
	 */
	void enterFunc_expr(GrammarParser.Func_exprContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#func_expr}.
	 * @param ctx the parse tree
	 */
	void exitFunc_expr(GrammarParser.Func_exprContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#iter_stmt}.
	 * @param ctx the parse tree
	 */
	void enterIter_stmt(GrammarParser.Iter_stmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#iter_stmt}.
	 * @param ctx the parse tree
	 */
	void exitIter_stmt(GrammarParser.Iter_stmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#print}.
	 * @param ctx the parse tree
	 */
	void enterPrint(GrammarParser.PrintContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#print}.
	 * @param ctx the parse tree
	 */
	void exitPrint(GrammarParser.PrintContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#expr}.
	 * @param ctx the parse tree
	 */
	void enterExpr(GrammarParser.ExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#expr}.
	 * @param ctx the parse tree
	 */
	void exitExpr(GrammarParser.ExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#var_expr}.
	 * @param ctx the parse tree
	 */
	void enterVar_expr(GrammarParser.Var_exprContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#var_expr}.
	 * @param ctx the parse tree
	 */
	void exitVar_expr(GrammarParser.Var_exprContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#num_expr}.
	 * @param ctx the parse tree
	 */
	void enterNum_expr(GrammarParser.Num_exprContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#num_expr}.
	 * @param ctx the parse tree
	 */
	void exitNum_expr(GrammarParser.Num_exprContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#logic_expr}.
	 * @param ctx the parse tree
	 */
	void enterLogic_expr(GrammarParser.Logic_exprContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#logic_expr}.
	 * @param ctx the parse tree
	 */
	void exitLogic_expr(GrammarParser.Logic_exprContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#var_stmt}.
	 * @param ctx the parse tree
	 */
	void enterVar_stmt(GrammarParser.Var_stmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#var_stmt}.
	 * @param ctx the parse tree
	 */
	void exitVar_stmt(GrammarParser.Var_stmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#return_stmt}.
	 * @param ctx the parse tree
	 */
	void enterReturn_stmt(GrammarParser.Return_stmtContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#return_stmt}.
	 * @param ctx the parse tree
	 */
	void exitReturn_stmt(GrammarParser.Return_stmtContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#compileUnit}.
	 * @param ctx the parse tree
	 */
	void enterCompileUnit(GrammarParser.CompileUnitContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#compileUnit}.
	 * @param ctx the parse tree
	 */
	void exitCompileUnit(GrammarParser.CompileUnitContext ctx);
}