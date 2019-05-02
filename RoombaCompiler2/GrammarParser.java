// Generated from Grammar.g4 by ANTLR 4.7.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class GrammarParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, ADDARRAY=13, AND=14, OR=15, LT=16, GT=17, 
		GTEQ=18, LTEQ=19, NEQ=20, EQ=21, INTDECL=22, FLOATDECL=23, BOOLDECL=24, 
		LISTDECL=25, VOID=26, IF=27, ELSEIF=28, ELSE=29, WHILE=30, FOR=31, MUL=32, 
		DIV=33, ADD=34, SUB=35, BOOL=36, IDENTIFIER=37, INT=38, FLOAT=39, COMMENT=40, 
		WS=41;
	public static final int
		RULE_program = 0, RULE_stmts = 1, RULE_stmt = 2, RULE_var_decl = 3, RULE_cond_stmt = 4, 
		RULE_if_stmt = 5, RULE_elseif_stmt = 6, RULE_else_stmt = 7, RULE_parameter_decl = 8, 
		RULE_func_stmt = 9, RULE_func_expr = 10, RULE_iter_stmt = 11, RULE_print = 12, 
		RULE_expr = 13, RULE_var_expr = 14, RULE_num_expr = 15, RULE_logic_expr = 16, 
		RULE_var_stmt = 17, RULE_return_stmt = 18, RULE_compileUnit = 19;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "stmts", "stmt", "var_decl", "cond_stmt", "if_stmt", "elseif_stmt", 
			"else_stmt", "parameter_decl", "func_stmt", "func_expr", "iter_stmt", 
			"print", "expr", "var_expr", "num_expr", "logic_expr", "var_stmt", "return_stmt", 
			"compileUnit"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'Program'", "'{'", "'}'", "'='", "'['", "','", "']'", "'('", "')'", 
			"'to'", "'print'", "'return'", "'add'", null, null, "'<'", "'>'", "'>='", 
			"'<='", "'!='", "'=='", "'int'", "'float'", "'bool'", "'[]'", "'void'", 
			"'if'", "'elseif'", "'else'", "'while'", "'for'", "'*'", "'/'", "'+'", 
			"'-'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, "ADDARRAY", "AND", "OR", "LT", "GT", "GTEQ", "LTEQ", "NEQ", "EQ", 
			"INTDECL", "FLOATDECL", "BOOLDECL", "LISTDECL", "VOID", "IF", "ELSEIF", 
			"ELSE", "WHILE", "FOR", "MUL", "DIV", "ADD", "SUB", "BOOL", "IDENTIFIER", 
			"INT", "FLOAT", "COMMENT", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Grammar.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public GrammarParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public List<Var_declContext> var_decl() {
			return getRuleContexts(Var_declContext.class);
		}
		public Var_declContext var_decl(int i) {
			return getRuleContext(Var_declContext.class,i);
		}
		public List<Func_stmtContext> func_stmt() {
			return getRuleContexts(Func_stmtContext.class);
		}
		public Func_stmtContext func_stmt(int i) {
			return getRuleContext(Func_stmtContext.class,i);
		}
		public StmtsContext stmts() {
			return getRuleContext(StmtsContext.class,0);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitProgram(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitProgram(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(44);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTDECL) | (1L << FLOATDECL) | (1L << BOOLDECL) | (1L << VOID))) != 0)) {
				{
				setState(42);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
				case 1:
					{
					setState(40);
					var_decl();
					}
					break;
				case 2:
					{
					setState(41);
					func_stmt();
					}
					break;
				}
				}
				setState(46);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(47);
			match(T__0);
			setState(48);
			match(T__1);
			setState(50);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				{
				setState(49);
				stmts();
				}
				break;
			}
			setState(52);
			match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StmtsContext extends ParserRuleContext {
		public List<StmtContext> stmt() {
			return getRuleContexts(StmtContext.class);
		}
		public StmtContext stmt(int i) {
			return getRuleContext(StmtContext.class,i);
		}
		public StmtsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmts; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterStmts(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitStmts(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitStmts(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StmtsContext stmts() throws RecognitionException {
		StmtsContext _localctx = new StmtsContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_stmts);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(57);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__10) | (1L << INTDECL) | (1L << FLOATDECL) | (1L << BOOLDECL) | (1L << IF) | (1L << WHILE) | (1L << FOR) | (1L << IDENTIFIER))) != 0)) {
				{
				{
				setState(54);
				stmt();
				}
				}
				setState(59);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StmtContext extends ParserRuleContext {
		public Var_stmtContext var_stmt() {
			return getRuleContext(Var_stmtContext.class,0);
		}
		public Var_declContext var_decl() {
			return getRuleContext(Var_declContext.class,0);
		}
		public Iter_stmtContext iter_stmt() {
			return getRuleContext(Iter_stmtContext.class,0);
		}
		public Cond_stmtContext cond_stmt() {
			return getRuleContext(Cond_stmtContext.class,0);
		}
		public Func_exprContext func_expr() {
			return getRuleContext(Func_exprContext.class,0);
		}
		public PrintContext print() {
			return getRuleContext(PrintContext.class,0);
		}
		public StmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterStmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitStmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitStmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StmtContext stmt() throws RecognitionException {
		StmtContext _localctx = new StmtContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_stmt);
		try {
			setState(66);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(60);
				var_stmt();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(61);
				var_decl();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(62);
				iter_stmt();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(63);
				cond_stmt();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(64);
				func_expr();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(65);
				print();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Var_declContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(GrammarParser.IDENTIFIER, 0); }
		public TerminalNode INTDECL() { return getToken(GrammarParser.INTDECL, 0); }
		public TerminalNode FLOATDECL() { return getToken(GrammarParser.FLOATDECL, 0); }
		public TerminalNode BOOLDECL() { return getToken(GrammarParser.BOOLDECL, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Logic_exprContext> logic_expr() {
			return getRuleContexts(Logic_exprContext.class);
		}
		public Logic_exprContext logic_expr(int i) {
			return getRuleContext(Logic_exprContext.class,i);
		}
		public TerminalNode LISTDECL() { return getToken(GrammarParser.LISTDECL, 0); }
		public Var_declContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_var_decl; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterVar_decl(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitVar_decl(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitVar_decl(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Var_declContext var_decl() throws RecognitionException {
		Var_declContext _localctx = new Var_declContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_var_decl);
		int _la;
		try {
			setState(97);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(68);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTDECL) | (1L << FLOATDECL) | (1L << BOOLDECL))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(69);
				match(IDENTIFIER);
				setState(70);
				match(T__3);
				setState(73);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
				case 1:
					{
					setState(71);
					expr();
					}
					break;
				case 2:
					{
					setState(72);
					logic_expr(0);
					}
					break;
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(75);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTDECL) | (1L << FLOATDECL) | (1L << BOOLDECL))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(76);
				match(LISTDECL);
				setState(77);
				match(IDENTIFIER);
				setState(78);
				match(T__3);
				setState(79);
				match(T__4);
				setState(94);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
				case 1:
					{
					setState(82);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
					case 1:
						{
						setState(80);
						expr();
						}
						break;
					case 2:
						{
						setState(81);
						logic_expr(0);
						}
						break;
					}
					setState(91);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==T__5) {
						{
						{
						setState(84);
						match(T__5);
						setState(87);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
						case 1:
							{
							setState(85);
							expr();
							}
							break;
						case 2:
							{
							setState(86);
							logic_expr(0);
							}
							break;
						}
						}
						}
						setState(93);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
					break;
				}
				setState(96);
				match(T__6);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Cond_stmtContext extends ParserRuleContext {
		public If_stmtContext if_stmt() {
			return getRuleContext(If_stmtContext.class,0);
		}
		public List<Elseif_stmtContext> elseif_stmt() {
			return getRuleContexts(Elseif_stmtContext.class);
		}
		public Elseif_stmtContext elseif_stmt(int i) {
			return getRuleContext(Elseif_stmtContext.class,i);
		}
		public Else_stmtContext else_stmt() {
			return getRuleContext(Else_stmtContext.class,0);
		}
		public Cond_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cond_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterCond_stmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitCond_stmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitCond_stmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Cond_stmtContext cond_stmt() throws RecognitionException {
		Cond_stmtContext _localctx = new Cond_stmtContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_cond_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(99);
			if_stmt();
			setState(103);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==ELSEIF) {
				{
				{
				setState(100);
				elseif_stmt();
				}
				}
				setState(105);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(107);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(106);
				else_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class If_stmtContext extends ParserRuleContext {
		public TerminalNode IF() { return getToken(GrammarParser.IF, 0); }
		public Logic_exprContext logic_expr() {
			return getRuleContext(Logic_exprContext.class,0);
		}
		public StmtsContext stmts() {
			return getRuleContext(StmtsContext.class,0);
		}
		public If_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_if_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterIf_stmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitIf_stmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitIf_stmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final If_stmtContext if_stmt() throws RecognitionException {
		If_stmtContext _localctx = new If_stmtContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_if_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			match(IF);
			setState(110);
			logic_expr(0);
			setState(111);
			match(T__1);
			setState(113);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				{
				setState(112);
				stmts();
				}
				break;
			}
			setState(115);
			match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Elseif_stmtContext extends ParserRuleContext {
		public TerminalNode ELSEIF() { return getToken(GrammarParser.ELSEIF, 0); }
		public Logic_exprContext logic_expr() {
			return getRuleContext(Logic_exprContext.class,0);
		}
		public StmtsContext stmts() {
			return getRuleContext(StmtsContext.class,0);
		}
		public Elseif_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elseif_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterElseif_stmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitElseif_stmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitElseif_stmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Elseif_stmtContext elseif_stmt() throws RecognitionException {
		Elseif_stmtContext _localctx = new Elseif_stmtContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_elseif_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(117);
			match(ELSEIF);
			setState(118);
			logic_expr(0);
			setState(119);
			match(T__1);
			setState(121);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				{
				setState(120);
				stmts();
				}
				break;
			}
			setState(123);
			match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Else_stmtContext extends ParserRuleContext {
		public TerminalNode ELSE() { return getToken(GrammarParser.ELSE, 0); }
		public StmtsContext stmts() {
			return getRuleContext(StmtsContext.class,0);
		}
		public Else_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_else_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterElse_stmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitElse_stmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitElse_stmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Else_stmtContext else_stmt() throws RecognitionException {
		Else_stmtContext _localctx = new Else_stmtContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_else_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(125);
			match(ELSE);
			setState(126);
			match(T__1);
			setState(128);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				{
				setState(127);
				stmts();
				}
				break;
			}
			setState(130);
			match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Parameter_declContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(GrammarParser.IDENTIFIER, 0); }
		public TerminalNode INTDECL() { return getToken(GrammarParser.INTDECL, 0); }
		public TerminalNode FLOATDECL() { return getToken(GrammarParser.FLOATDECL, 0); }
		public TerminalNode BOOLDECL() { return getToken(GrammarParser.BOOLDECL, 0); }
		public TerminalNode LISTDECL() { return getToken(GrammarParser.LISTDECL, 0); }
		public Parameter_declContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameter_decl; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterParameter_decl(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitParameter_decl(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitParameter_decl(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Parameter_declContext parameter_decl() throws RecognitionException {
		Parameter_declContext _localctx = new Parameter_declContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_parameter_decl);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(132);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTDECL) | (1L << FLOATDECL) | (1L << BOOLDECL))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(134);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LISTDECL) {
				{
				setState(133);
				match(LISTDECL);
				}
			}

			setState(136);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Func_stmtContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(GrammarParser.IDENTIFIER, 0); }
		public Return_stmtContext return_stmt() {
			return getRuleContext(Return_stmtContext.class,0);
		}
		public TerminalNode INTDECL() { return getToken(GrammarParser.INTDECL, 0); }
		public TerminalNode FLOATDECL() { return getToken(GrammarParser.FLOATDECL, 0); }
		public TerminalNode BOOLDECL() { return getToken(GrammarParser.BOOLDECL, 0); }
		public List<Parameter_declContext> parameter_decl() {
			return getRuleContexts(Parameter_declContext.class);
		}
		public Parameter_declContext parameter_decl(int i) {
			return getRuleContext(Parameter_declContext.class,i);
		}
		public StmtsContext stmts() {
			return getRuleContext(StmtsContext.class,0);
		}
		public TerminalNode VOID() { return getToken(GrammarParser.VOID, 0); }
		public Func_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_func_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterFunc_stmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitFunc_stmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitFunc_stmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Func_stmtContext func_stmt() throws RecognitionException {
		Func_stmtContext _localctx = new Func_stmtContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_func_stmt);
		int _la;
		try {
			setState(177);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INTDECL:
			case FLOATDECL:
			case BOOLDECL:
				enterOuterAlt(_localctx, 1);
				{
				setState(138);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTDECL) | (1L << FLOATDECL) | (1L << BOOLDECL))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(139);
				match(IDENTIFIER);
				setState(140);
				match(T__7);
				setState(149);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTDECL) | (1L << FLOATDECL) | (1L << BOOLDECL))) != 0)) {
					{
					setState(141);
					parameter_decl();
					setState(146);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==T__5) {
						{
						{
						setState(142);
						match(T__5);
						setState(143);
						parameter_decl();
						}
						}
						setState(148);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(151);
				match(T__8);
				setState(152);
				match(T__1);
				setState(154);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
				case 1:
					{
					setState(153);
					stmts();
					}
					break;
				}
				setState(156);
				return_stmt();
				setState(157);
				match(T__2);
				}
				break;
			case VOID:
				enterOuterAlt(_localctx, 2);
				{
				setState(159);
				match(VOID);
				setState(160);
				match(IDENTIFIER);
				setState(161);
				match(T__7);
				setState(162);
				parameter_decl();
				setState(167);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__5) {
					{
					{
					setState(163);
					match(T__5);
					setState(164);
					parameter_decl();
					}
					}
					setState(169);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(170);
				match(T__8);
				setState(171);
				match(T__1);
				setState(173);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
				case 1:
					{
					setState(172);
					stmts();
					}
					break;
				}
				setState(175);
				match(T__2);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Func_exprContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(GrammarParser.IDENTIFIER, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Logic_exprContext> logic_expr() {
			return getRuleContexts(Logic_exprContext.class);
		}
		public Logic_exprContext logic_expr(int i) {
			return getRuleContext(Logic_exprContext.class,i);
		}
		public Func_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_func_expr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterFunc_expr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitFunc_expr(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitFunc_expr(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Func_exprContext func_expr() throws RecognitionException {
		Func_exprContext _localctx = new Func_exprContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_func_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(179);
			match(IDENTIFIER);
			setState(180);
			match(T__7);
			setState(195);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				{
				setState(183);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,23,_ctx) ) {
				case 1:
					{
					setState(181);
					expr();
					}
					break;
				case 2:
					{
					setState(182);
					logic_expr(0);
					}
					break;
				}
				setState(192);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__5) {
					{
					{
					setState(185);
					match(T__5);
					setState(188);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
					case 1:
						{
						setState(186);
						expr();
						}
						break;
					case 2:
						{
						setState(187);
						logic_expr(0);
						}
						break;
					}
					}
					}
					setState(194);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			}
			setState(197);
			match(T__8);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Iter_stmtContext extends ParserRuleContext {
		public TerminalNode WHILE() { return getToken(GrammarParser.WHILE, 0); }
		public Logic_exprContext logic_expr() {
			return getRuleContext(Logic_exprContext.class,0);
		}
		public StmtsContext stmts() {
			return getRuleContext(StmtsContext.class,0);
		}
		public TerminalNode FOR() { return getToken(GrammarParser.FOR, 0); }
		public TerminalNode IDENTIFIER() { return getToken(GrammarParser.IDENTIFIER, 0); }
		public List<TerminalNode> INT() { return getTokens(GrammarParser.INT); }
		public TerminalNode INT(int i) {
			return getToken(GrammarParser.INT, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Iter_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_iter_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterIter_stmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitIter_stmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitIter_stmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Iter_stmtContext iter_stmt() throws RecognitionException {
		Iter_stmtContext _localctx = new Iter_stmtContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_iter_stmt);
		try {
			setState(224);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WHILE:
				enterOuterAlt(_localctx, 1);
				{
				setState(199);
				match(WHILE);
				setState(200);
				logic_expr(0);
				setState(201);
				match(T__1);
				setState(203);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
				case 1:
					{
					setState(202);
					stmts();
					}
					break;
				}
				setState(205);
				match(T__2);
				}
				break;
			case FOR:
				enterOuterAlt(_localctx, 2);
				{
				setState(207);
				match(FOR);
				setState(208);
				match(IDENTIFIER);
				setState(209);
				match(T__3);
				setState(212);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,28,_ctx) ) {
				case 1:
					{
					setState(210);
					match(INT);
					}
					break;
				case 2:
					{
					setState(211);
					expr();
					}
					break;
				}
				setState(214);
				match(T__9);
				setState(217);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
				case 1:
					{
					setState(215);
					match(INT);
					}
					break;
				case 2:
					{
					setState(216);
					expr();
					}
					break;
				}
				setState(219);
				match(T__1);
				setState(221);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
				case 1:
					{
					setState(220);
					stmts();
					}
					break;
				}
				setState(223);
				match(T__2);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PrintContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Logic_exprContext logic_expr() {
			return getRuleContext(Logic_exprContext.class,0);
		}
		public PrintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_print; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterPrint(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitPrint(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitPrint(this);
			else return visitor.visitChildren(this);
		}
	}

	public final PrintContext print() throws RecognitionException {
		PrintContext _localctx = new PrintContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_print);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(226);
			match(T__10);
			setState(229);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,32,_ctx) ) {
			case 1:
				{
				setState(227);
				expr();
				}
				break;
			case 2:
				{
				setState(228);
				logic_expr(0);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExprContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Var_exprContext var_expr() {
			return getRuleContext(Var_exprContext.class,0);
		}
		public Num_exprContext num_expr() {
			return getRuleContext(Num_exprContext.class,0);
		}
		public Func_exprContext func_expr() {
			return getRuleContext(Func_exprContext.class,0);
		}
		public Logic_exprContext logic_expr() {
			return getRuleContext(Logic_exprContext.class,0);
		}
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterExpr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitExpr(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitExpr(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ExprContext expr() throws RecognitionException {
		ExprContext _localctx = new ExprContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_expr);
		try {
			setState(240);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,34,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(231);
				match(T__7);
				setState(233);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,33,_ctx) ) {
				case 1:
					{
					setState(232);
					expr();
					}
					break;
				}
				setState(235);
				match(T__8);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(236);
				var_expr();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(237);
				num_expr(0);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(238);
				func_expr();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(239);
				logic_expr(0);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Var_exprContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(GrammarParser.IDENTIFIER, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Var_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_var_expr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterVar_expr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitVar_expr(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitVar_expr(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Var_exprContext var_expr() throws RecognitionException {
		Var_exprContext _localctx = new Var_exprContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_var_expr);
		try {
			setState(248);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,35,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(242);
				match(IDENTIFIER);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(243);
				match(IDENTIFIER);
				setState(244);
				match(T__4);
				setState(245);
				expr();
				setState(246);
				match(T__6);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Num_exprContext extends ParserRuleContext {
		public Token op;
		public Var_exprContext var_expr() {
			return getRuleContext(Var_exprContext.class,0);
		}
		public Func_exprContext func_expr() {
			return getRuleContext(Func_exprContext.class,0);
		}
		public TerminalNode INT() { return getToken(GrammarParser.INT, 0); }
		public TerminalNode FLOAT() { return getToken(GrammarParser.FLOAT, 0); }
		public List<Num_exprContext> num_expr() {
			return getRuleContexts(Num_exprContext.class);
		}
		public Num_exprContext num_expr(int i) {
			return getRuleContext(Num_exprContext.class,i);
		}
		public TerminalNode MUL() { return getToken(GrammarParser.MUL, 0); }
		public TerminalNode DIV() { return getToken(GrammarParser.DIV, 0); }
		public TerminalNode ADD() { return getToken(GrammarParser.ADD, 0); }
		public TerminalNode SUB() { return getToken(GrammarParser.SUB, 0); }
		public Num_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_num_expr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterNum_expr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitNum_expr(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitNum_expr(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Num_exprContext num_expr() throws RecognitionException {
		return num_expr(0);
	}

	private Num_exprContext num_expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		Num_exprContext _localctx = new Num_exprContext(_ctx, _parentState);
		Num_exprContext _prevctx = _localctx;
		int _startState = 30;
		enterRecursionRule(_localctx, 30, RULE_num_expr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(256);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,36,_ctx) ) {
			case 1:
				{
				setState(251);
				var_expr();
				}
				break;
			case 2:
				{
				setState(252);
				func_expr();
				}
				break;
			case 3:
				{
				setState(253);
				match(INT);
				}
				break;
			case 4:
				{
				setState(254);
				match(FLOAT);
				}
				break;
			case 5:
				{
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(266);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,38,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(264);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
					case 1:
						{
						_localctx = new Num_exprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_num_expr);
						setState(258);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(259);
						((Num_exprContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !(_la==MUL || _la==DIV) ) {
							((Num_exprContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(260);
						num_expr(8);
						}
						break;
					case 2:
						{
						_localctx = new Num_exprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_num_expr);
						setState(261);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(262);
						((Num_exprContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !(_la==ADD || _la==SUB) ) {
							((Num_exprContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(263);
						num_expr(7);
						}
						break;
					}
					} 
				}
				setState(268);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,38,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class Logic_exprContext extends ParserRuleContext {
		public List<Logic_exprContext> logic_expr() {
			return getRuleContexts(Logic_exprContext.class);
		}
		public Logic_exprContext logic_expr(int i) {
			return getRuleContext(Logic_exprContext.class,i);
		}
		public TerminalNode BOOL() { return getToken(GrammarParser.BOOL, 0); }
		public List<Var_exprContext> var_expr() {
			return getRuleContexts(Var_exprContext.class);
		}
		public Var_exprContext var_expr(int i) {
			return getRuleContext(Var_exprContext.class,i);
		}
		public List<Func_exprContext> func_expr() {
			return getRuleContexts(Func_exprContext.class);
		}
		public Func_exprContext func_expr(int i) {
			return getRuleContext(Func_exprContext.class,i);
		}
		public TerminalNode LT() { return getToken(GrammarParser.LT, 0); }
		public TerminalNode LTEQ() { return getToken(GrammarParser.LTEQ, 0); }
		public TerminalNode GT() { return getToken(GrammarParser.GT, 0); }
		public TerminalNode GTEQ() { return getToken(GrammarParser.GTEQ, 0); }
		public List<Num_exprContext> num_expr() {
			return getRuleContexts(Num_exprContext.class);
		}
		public Num_exprContext num_expr(int i) {
			return getRuleContext(Num_exprContext.class,i);
		}
		public TerminalNode EQ() { return getToken(GrammarParser.EQ, 0); }
		public TerminalNode NEQ() { return getToken(GrammarParser.NEQ, 0); }
		public TerminalNode AND() { return getToken(GrammarParser.AND, 0); }
		public TerminalNode OR() { return getToken(GrammarParser.OR, 0); }
		public Logic_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logic_expr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterLogic_expr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitLogic_expr(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitLogic_expr(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Logic_exprContext logic_expr() throws RecognitionException {
		return logic_expr(0);
	}

	private Logic_exprContext logic_expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		Logic_exprContext _localctx = new Logic_exprContext(_ctx, _parentState);
		Logic_exprContext _prevctx = _localctx;
		int _startState = 32;
		enterRecursionRule(_localctx, 32, RULE_logic_expr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(301);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,44,_ctx) ) {
			case 1:
				{
				setState(270);
				match(T__7);
				setState(271);
				logic_expr(0);
				setState(272);
				match(T__8);
				}
				break;
			case 2:
				{
				setState(277);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,39,_ctx) ) {
				case 1:
					{
					setState(274);
					match(BOOL);
					}
					break;
				case 2:
					{
					setState(275);
					var_expr();
					}
					break;
				case 3:
					{
					setState(276);
					func_expr();
					}
					break;
				}
				}
				break;
			case 3:
				{
				setState(282);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
				case 1:
					{
					setState(279);
					var_expr();
					}
					break;
				case 2:
					{
					setState(280);
					func_expr();
					}
					break;
				case 3:
					{
					setState(281);
					num_expr(0);
					}
					break;
				}
				setState(284);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LT) | (1L << GT) | (1L << GTEQ) | (1L << LTEQ))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(288);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,41,_ctx) ) {
				case 1:
					{
					setState(285);
					var_expr();
					}
					break;
				case 2:
					{
					setState(286);
					func_expr();
					}
					break;
				case 3:
					{
					setState(287);
					num_expr(0);
					}
					break;
				}
				}
				break;
			case 4:
				{
				setState(293);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,42,_ctx) ) {
				case 1:
					{
					setState(290);
					var_expr();
					}
					break;
				case 2:
					{
					setState(291);
					func_expr();
					}
					break;
				case 3:
					{
					setState(292);
					num_expr(0);
					}
					break;
				}
				setState(295);
				_la = _input.LA(1);
				if ( !(_la==NEQ || _la==EQ) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(299);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,43,_ctx) ) {
				case 1:
					{
					setState(296);
					var_expr();
					}
					break;
				case 2:
					{
					setState(297);
					func_expr();
					}
					break;
				case 3:
					{
					setState(298);
					num_expr(0);
					}
					break;
				}
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(308);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,45,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new Logic_exprContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_logic_expr);
					setState(303);
					if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
					setState(304);
					_la = _input.LA(1);
					if ( !(_la==AND || _la==OR) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(305);
					logic_expr(4);
					}
					} 
				}
				setState(310);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,45,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class Var_stmtContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(GrammarParser.IDENTIFIER, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Logic_exprContext logic_expr() {
			return getRuleContext(Logic_exprContext.class,0);
		}
		public TerminalNode ADDARRAY() { return getToken(GrammarParser.ADDARRAY, 0); }
		public Var_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_var_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterVar_stmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitVar_stmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitVar_stmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Var_stmtContext var_stmt() throws RecognitionException {
		Var_stmtContext _localctx = new Var_stmtContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_var_stmt);
		try {
			setState(332);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,49,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(311);
				match(IDENTIFIER);
				setState(312);
				match(T__3);
				setState(315);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,46,_ctx) ) {
				case 1:
					{
					setState(313);
					expr();
					}
					break;
				case 2:
					{
					setState(314);
					logic_expr(0);
					}
					break;
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(317);
				match(IDENTIFIER);
				setState(318);
				match(T__4);
				setState(319);
				expr();
				setState(320);
				match(T__6);
				setState(321);
				match(T__3);
				setState(324);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,47,_ctx) ) {
				case 1:
					{
					setState(322);
					expr();
					}
					break;
				case 2:
					{
					setState(323);
					logic_expr(0);
					}
					break;
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(326);
				match(IDENTIFIER);
				setState(327);
				match(ADDARRAY);
				setState(330);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,48,_ctx) ) {
				case 1:
					{
					setState(328);
					expr();
					}
					break;
				case 2:
					{
					setState(329);
					logic_expr(0);
					}
					break;
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Return_stmtContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Logic_exprContext logic_expr() {
			return getRuleContext(Logic_exprContext.class,0);
		}
		public Return_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_return_stmt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterReturn_stmt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitReturn_stmt(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitReturn_stmt(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Return_stmtContext return_stmt() throws RecognitionException {
		Return_stmtContext _localctx = new Return_stmtContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_return_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(334);
			match(T__11);
			setState(337);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,50,_ctx) ) {
			case 1:
				{
				setState(335);
				expr();
				}
				break;
			case 2:
				{
				setState(336);
				logic_expr(0);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CompileUnitContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(GrammarParser.EOF, 0); }
		public CompileUnitContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compileUnit; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).enterCompileUnit(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof GrammarListener ) ((GrammarListener)listener).exitCompileUnit(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof GrammarVisitor ) return ((GrammarVisitor<? extends T>)visitor).visitCompileUnit(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CompileUnitContext compileUnit() throws RecognitionException {
		CompileUnitContext _localctx = new CompileUnitContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_compileUnit);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(339);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 15:
			return num_expr_sempred((Num_exprContext)_localctx, predIndex);
		case 16:
			return logic_expr_sempred((Logic_exprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean num_expr_sempred(Num_exprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 7);
		case 1:
			return precpred(_ctx, 6);
		}
		return true;
	}
	private boolean logic_expr_sempred(Logic_exprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 2:
			return precpred(_ctx, 3);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3+\u0158\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\3\2\3\2\7\2-\n\2\f\2\16\2\60\13\2\3\2\3"+
		"\2\3\2\5\2\65\n\2\3\2\3\2\3\3\7\3:\n\3\f\3\16\3=\13\3\3\4\3\4\3\4\3\4"+
		"\3\4\3\4\5\4E\n\4\3\5\3\5\3\5\3\5\3\5\5\5L\n\5\3\5\3\5\3\5\3\5\3\5\3\5"+
		"\3\5\5\5U\n\5\3\5\3\5\3\5\5\5Z\n\5\7\5\\\n\5\f\5\16\5_\13\5\5\5a\n\5\3"+
		"\5\5\5d\n\5\3\6\3\6\7\6h\n\6\f\6\16\6k\13\6\3\6\5\6n\n\6\3\7\3\7\3\7\3"+
		"\7\5\7t\n\7\3\7\3\7\3\b\3\b\3\b\3\b\5\b|\n\b\3\b\3\b\3\t\3\t\3\t\5\t\u0083"+
		"\n\t\3\t\3\t\3\n\3\n\5\n\u0089\n\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3"+
		"\13\7\13\u0093\n\13\f\13\16\13\u0096\13\13\5\13\u0098\n\13\3\13\3\13\3"+
		"\13\5\13\u009d\n\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\7\13"+
		"\u00a8\n\13\f\13\16\13\u00ab\13\13\3\13\3\13\3\13\5\13\u00b0\n\13\3\13"+
		"\3\13\5\13\u00b4\n\13\3\f\3\f\3\f\3\f\5\f\u00ba\n\f\3\f\3\f\3\f\5\f\u00bf"+
		"\n\f\7\f\u00c1\n\f\f\f\16\f\u00c4\13\f\5\f\u00c6\n\f\3\f\3\f\3\r\3\r\3"+
		"\r\3\r\5\r\u00ce\n\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\5\r\u00d7\n\r\3\r\3\r"+
		"\3\r\5\r\u00dc\n\r\3\r\3\r\5\r\u00e0\n\r\3\r\5\r\u00e3\n\r\3\16\3\16\3"+
		"\16\5\16\u00e8\n\16\3\17\3\17\5\17\u00ec\n\17\3\17\3\17\3\17\3\17\3\17"+
		"\5\17\u00f3\n\17\3\20\3\20\3\20\3\20\3\20\3\20\5\20\u00fb\n\20\3\21\3"+
		"\21\3\21\3\21\3\21\3\21\5\21\u0103\n\21\3\21\3\21\3\21\3\21\3\21\3\21"+
		"\7\21\u010b\n\21\f\21\16\21\u010e\13\21\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\5\22\u0118\n\22\3\22\3\22\3\22\5\22\u011d\n\22\3\22\3\22\3"+
		"\22\3\22\5\22\u0123\n\22\3\22\3\22\3\22\5\22\u0128\n\22\3\22\3\22\3\22"+
		"\3\22\5\22\u012e\n\22\5\22\u0130\n\22\3\22\3\22\3\22\7\22\u0135\n\22\f"+
		"\22\16\22\u0138\13\22\3\23\3\23\3\23\3\23\5\23\u013e\n\23\3\23\3\23\3"+
		"\23\3\23\3\23\3\23\3\23\5\23\u0147\n\23\3\23\3\23\3\23\3\23\5\23\u014d"+
		"\n\23\5\23\u014f\n\23\3\24\3\24\3\24\5\24\u0154\n\24\3\25\3\25\3\25\2"+
		"\4 \"\26\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(\2\b\3\2\30\32\3"+
		"\2\"#\3\2$%\3\2\22\25\3\2\26\27\3\2\20\21\2\u0188\2.\3\2\2\2\4;\3\2\2"+
		"\2\6D\3\2\2\2\bc\3\2\2\2\ne\3\2\2\2\fo\3\2\2\2\16w\3\2\2\2\20\177\3\2"+
		"\2\2\22\u0086\3\2\2\2\24\u00b3\3\2\2\2\26\u00b5\3\2\2\2\30\u00e2\3\2\2"+
		"\2\32\u00e4\3\2\2\2\34\u00f2\3\2\2\2\36\u00fa\3\2\2\2 \u0102\3\2\2\2\""+
		"\u012f\3\2\2\2$\u014e\3\2\2\2&\u0150\3\2\2\2(\u0155\3\2\2\2*-\5\b\5\2"+
		"+-\5\24\13\2,*\3\2\2\2,+\3\2\2\2-\60\3\2\2\2.,\3\2\2\2./\3\2\2\2/\61\3"+
		"\2\2\2\60.\3\2\2\2\61\62\7\3\2\2\62\64\7\4\2\2\63\65\5\4\3\2\64\63\3\2"+
		"\2\2\64\65\3\2\2\2\65\66\3\2\2\2\66\67\7\5\2\2\67\3\3\2\2\28:\5\6\4\2"+
		"98\3\2\2\2:=\3\2\2\2;9\3\2\2\2;<\3\2\2\2<\5\3\2\2\2=;\3\2\2\2>E\5$\23"+
		"\2?E\5\b\5\2@E\5\30\r\2AE\5\n\6\2BE\5\26\f\2CE\5\32\16\2D>\3\2\2\2D?\3"+
		"\2\2\2D@\3\2\2\2DA\3\2\2\2DB\3\2\2\2DC\3\2\2\2E\7\3\2\2\2FG\t\2\2\2GH"+
		"\7\'\2\2HK\7\6\2\2IL\5\34\17\2JL\5\"\22\2KI\3\2\2\2KJ\3\2\2\2Ld\3\2\2"+
		"\2MN\t\2\2\2NO\7\33\2\2OP\7\'\2\2PQ\7\6\2\2Q`\7\7\2\2RU\5\34\17\2SU\5"+
		"\"\22\2TR\3\2\2\2TS\3\2\2\2U]\3\2\2\2VY\7\b\2\2WZ\5\34\17\2XZ\5\"\22\2"+
		"YW\3\2\2\2YX\3\2\2\2Z\\\3\2\2\2[V\3\2\2\2\\_\3\2\2\2][\3\2\2\2]^\3\2\2"+
		"\2^a\3\2\2\2_]\3\2\2\2`T\3\2\2\2`a\3\2\2\2ab\3\2\2\2bd\7\t\2\2cF\3\2\2"+
		"\2cM\3\2\2\2d\t\3\2\2\2ei\5\f\7\2fh\5\16\b\2gf\3\2\2\2hk\3\2\2\2ig\3\2"+
		"\2\2ij\3\2\2\2jm\3\2\2\2ki\3\2\2\2ln\5\20\t\2ml\3\2\2\2mn\3\2\2\2n\13"+
		"\3\2\2\2op\7\35\2\2pq\5\"\22\2qs\7\4\2\2rt\5\4\3\2sr\3\2\2\2st\3\2\2\2"+
		"tu\3\2\2\2uv\7\5\2\2v\r\3\2\2\2wx\7\36\2\2xy\5\"\22\2y{\7\4\2\2z|\5\4"+
		"\3\2{z\3\2\2\2{|\3\2\2\2|}\3\2\2\2}~\7\5\2\2~\17\3\2\2\2\177\u0080\7\37"+
		"\2\2\u0080\u0082\7\4\2\2\u0081\u0083\5\4\3\2\u0082\u0081\3\2\2\2\u0082"+
		"\u0083\3\2\2\2\u0083\u0084\3\2\2\2\u0084\u0085\7\5\2\2\u0085\21\3\2\2"+
		"\2\u0086\u0088\t\2\2\2\u0087\u0089\7\33\2\2\u0088\u0087\3\2\2\2\u0088"+
		"\u0089\3\2\2\2\u0089\u008a\3\2\2\2\u008a\u008b\7\'\2\2\u008b\23\3\2\2"+
		"\2\u008c\u008d\t\2\2\2\u008d\u008e\7\'\2\2\u008e\u0097\7\n\2\2\u008f\u0094"+
		"\5\22\n\2\u0090\u0091\7\b\2\2\u0091\u0093\5\22\n\2\u0092\u0090\3\2\2\2"+
		"\u0093\u0096\3\2\2\2\u0094\u0092\3\2\2\2\u0094\u0095\3\2\2\2\u0095\u0098"+
		"\3\2\2\2\u0096\u0094\3\2\2\2\u0097\u008f\3\2\2\2\u0097\u0098\3\2\2\2\u0098"+
		"\u0099\3\2\2\2\u0099\u009a\7\13\2\2\u009a\u009c\7\4\2\2\u009b\u009d\5"+
		"\4\3\2\u009c\u009b\3\2\2\2\u009c\u009d\3\2\2\2\u009d\u009e\3\2\2\2\u009e"+
		"\u009f\5&\24\2\u009f\u00a0\7\5\2\2\u00a0\u00b4\3\2\2\2\u00a1\u00a2\7\34"+
		"\2\2\u00a2\u00a3\7\'\2\2\u00a3\u00a4\7\n\2\2\u00a4\u00a9\5\22\n\2\u00a5"+
		"\u00a6\7\b\2\2\u00a6\u00a8\5\22\n\2\u00a7\u00a5\3\2\2\2\u00a8\u00ab\3"+
		"\2\2\2\u00a9\u00a7\3\2\2\2\u00a9\u00aa\3\2\2\2\u00aa\u00ac\3\2\2\2\u00ab"+
		"\u00a9\3\2\2\2\u00ac\u00ad\7\13\2\2\u00ad\u00af\7\4\2\2\u00ae\u00b0\5"+
		"\4\3\2\u00af\u00ae\3\2\2\2\u00af\u00b0\3\2\2\2\u00b0\u00b1\3\2\2\2\u00b1"+
		"\u00b2\7\5\2\2\u00b2\u00b4\3\2\2\2\u00b3\u008c\3\2\2\2\u00b3\u00a1\3\2"+
		"\2\2\u00b4\25\3\2\2\2\u00b5\u00b6\7\'\2\2\u00b6\u00c5\7\n\2\2\u00b7\u00ba"+
		"\5\34\17\2\u00b8\u00ba\5\"\22\2\u00b9\u00b7\3\2\2\2\u00b9\u00b8\3\2\2"+
		"\2\u00ba\u00c2\3\2\2\2\u00bb\u00be\7\b\2\2\u00bc\u00bf\5\34\17\2\u00bd"+
		"\u00bf\5\"\22\2\u00be\u00bc\3\2\2\2\u00be\u00bd\3\2\2\2\u00bf\u00c1\3"+
		"\2\2\2\u00c0\u00bb\3\2\2\2\u00c1\u00c4\3\2\2\2\u00c2\u00c0\3\2\2\2\u00c2"+
		"\u00c3\3\2\2\2\u00c3\u00c6\3\2\2\2\u00c4\u00c2\3\2\2\2\u00c5\u00b9\3\2"+
		"\2\2\u00c5\u00c6\3\2\2\2\u00c6\u00c7\3\2\2\2\u00c7\u00c8\7\13\2\2\u00c8"+
		"\27\3\2\2\2\u00c9\u00ca\7 \2\2\u00ca\u00cb\5\"\22\2\u00cb\u00cd\7\4\2"+
		"\2\u00cc\u00ce\5\4\3\2\u00cd\u00cc\3\2\2\2\u00cd\u00ce\3\2\2\2\u00ce\u00cf"+
		"\3\2\2\2\u00cf\u00d0\7\5\2\2\u00d0\u00e3\3\2\2\2\u00d1\u00d2\7!\2\2\u00d2"+
		"\u00d3\7\'\2\2\u00d3\u00d6\7\6\2\2\u00d4\u00d7\7(\2\2\u00d5\u00d7\5\34"+
		"\17\2\u00d6\u00d4\3\2\2\2\u00d6\u00d5\3\2\2\2\u00d7\u00d8\3\2\2\2\u00d8"+
		"\u00db\7\f\2\2\u00d9\u00dc\7(\2\2\u00da\u00dc\5\34\17\2\u00db\u00d9\3"+
		"\2\2\2\u00db\u00da\3\2\2\2\u00dc\u00dd\3\2\2\2\u00dd\u00df\7\4\2\2\u00de"+
		"\u00e0\5\4\3\2\u00df\u00de\3\2\2\2\u00df\u00e0\3\2\2\2\u00e0\u00e1\3\2"+
		"\2\2\u00e1\u00e3\7\5\2\2\u00e2\u00c9\3\2\2\2\u00e2\u00d1\3\2\2\2\u00e3"+
		"\31\3\2\2\2\u00e4\u00e7\7\r\2\2\u00e5\u00e8\5\34\17\2\u00e6\u00e8\5\""+
		"\22\2\u00e7\u00e5\3\2\2\2\u00e7\u00e6\3\2\2\2\u00e8\33\3\2\2\2\u00e9\u00eb"+
		"\7\n\2\2\u00ea\u00ec\5\34\17\2\u00eb\u00ea\3\2\2\2\u00eb\u00ec\3\2\2\2"+
		"\u00ec\u00ed\3\2\2\2\u00ed\u00f3\7\13\2\2\u00ee\u00f3\5\36\20\2\u00ef"+
		"\u00f3\5 \21\2\u00f0\u00f3\5\26\f\2\u00f1\u00f3\5\"\22\2\u00f2\u00e9\3"+
		"\2\2\2\u00f2\u00ee\3\2\2\2\u00f2\u00ef\3\2\2\2\u00f2\u00f0\3\2\2\2\u00f2"+
		"\u00f1\3\2\2\2\u00f3\35\3\2\2\2\u00f4\u00fb\7\'\2\2\u00f5\u00f6\7\'\2"+
		"\2\u00f6\u00f7\7\7\2\2\u00f7\u00f8\5\34\17\2\u00f8\u00f9\7\t\2\2\u00f9"+
		"\u00fb\3\2\2\2\u00fa\u00f4\3\2\2\2\u00fa\u00f5\3\2\2\2\u00fb\37\3\2\2"+
		"\2\u00fc\u00fd\b\21\1\2\u00fd\u0103\5\36\20\2\u00fe\u0103\5\26\f\2\u00ff"+
		"\u0103\7(\2\2\u0100\u0103\7)\2\2\u0101\u0103\3\2\2\2\u0102\u00fc\3\2\2"+
		"\2\u0102\u00fe\3\2\2\2\u0102\u00ff\3\2\2\2\u0102\u0100\3\2\2\2\u0102\u0101"+
		"\3\2\2\2\u0103\u010c\3\2\2\2\u0104\u0105\f\t\2\2\u0105\u0106\t\3\2\2\u0106"+
		"\u010b\5 \21\n\u0107\u0108\f\b\2\2\u0108\u0109\t\4\2\2\u0109\u010b\5 "+
		"\21\t\u010a\u0104\3\2\2\2\u010a\u0107\3\2\2\2\u010b\u010e\3\2\2\2\u010c"+
		"\u010a\3\2\2\2\u010c\u010d\3\2\2\2\u010d!\3\2\2\2\u010e\u010c\3\2\2\2"+
		"\u010f\u0110\b\22\1\2\u0110\u0111\7\n\2\2\u0111\u0112\5\"\22\2\u0112\u0113"+
		"\7\13\2\2\u0113\u0130\3\2\2\2\u0114\u0118\7&\2\2\u0115\u0118\5\36\20\2"+
		"\u0116\u0118\5\26\f\2\u0117\u0114\3\2\2\2\u0117\u0115\3\2\2\2\u0117\u0116"+
		"\3\2\2\2\u0118\u0130\3\2\2\2\u0119\u011d\5\36\20\2\u011a\u011d\5\26\f"+
		"\2\u011b\u011d\5 \21\2\u011c\u0119\3\2\2\2\u011c\u011a\3\2\2\2\u011c\u011b"+
		"\3\2\2\2\u011d\u011e\3\2\2\2\u011e\u0122\t\5\2\2\u011f\u0123\5\36\20\2"+
		"\u0120\u0123\5\26\f\2\u0121\u0123\5 \21\2\u0122\u011f\3\2\2\2\u0122\u0120"+
		"\3\2\2\2\u0122\u0121\3\2\2\2\u0123\u0130\3\2\2\2\u0124\u0128\5\36\20\2"+
		"\u0125\u0128\5\26\f\2\u0126\u0128\5 \21\2\u0127\u0124\3\2\2\2\u0127\u0125"+
		"\3\2\2\2\u0127\u0126\3\2\2\2\u0128\u0129\3\2\2\2\u0129\u012d\t\6\2\2\u012a"+
		"\u012e\5\36\20\2\u012b\u012e\5\26\f\2\u012c\u012e\5 \21\2\u012d\u012a"+
		"\3\2\2\2\u012d\u012b\3\2\2\2\u012d\u012c\3\2\2\2\u012e\u0130\3\2\2\2\u012f"+
		"\u010f\3\2\2\2\u012f\u0117\3\2\2\2\u012f\u011c\3\2\2\2\u012f\u0127\3\2"+
		"\2\2\u0130\u0136\3\2\2\2\u0131\u0132\f\5\2\2\u0132\u0133\t\7\2\2\u0133"+
		"\u0135\5\"\22\6\u0134\u0131\3\2\2\2\u0135\u0138\3\2\2\2\u0136\u0134\3"+
		"\2\2\2\u0136\u0137\3\2\2\2\u0137#\3\2\2\2\u0138\u0136\3\2\2\2\u0139\u013a"+
		"\7\'\2\2\u013a\u013d\7\6\2\2\u013b\u013e\5\34\17\2\u013c\u013e\5\"\22"+
		"\2\u013d\u013b\3\2\2\2\u013d\u013c\3\2\2\2\u013e\u014f\3\2\2\2\u013f\u0140"+
		"\7\'\2\2\u0140\u0141\7\7\2\2\u0141\u0142\5\34\17\2\u0142\u0143\7\t\2\2"+
		"\u0143\u0146\7\6\2\2\u0144\u0147\5\34\17\2\u0145\u0147\5\"\22\2\u0146"+
		"\u0144\3\2\2\2\u0146\u0145\3\2\2\2\u0147\u014f\3\2\2\2\u0148\u0149\7\'"+
		"\2\2\u0149\u014c\7\17\2\2\u014a\u014d\5\34\17\2\u014b\u014d\5\"\22\2\u014c"+
		"\u014a\3\2\2\2\u014c\u014b\3\2\2\2\u014d\u014f\3\2\2\2\u014e\u0139\3\2"+
		"\2\2\u014e\u013f\3\2\2\2\u014e\u0148\3\2\2\2\u014f%\3\2\2\2\u0150\u0153"+
		"\7\16\2\2\u0151\u0154\5\34\17\2\u0152\u0154\5\"\22\2\u0153\u0151\3\2\2"+
		"\2\u0153\u0152\3\2\2\2\u0154\'\3\2\2\2\u0155\u0156\7\2\2\3\u0156)\3\2"+
		"\2\2\65,.\64;DKTY]`cims{\u0082\u0088\u0094\u0097\u009c\u00a9\u00af\u00b3"+
		"\u00b9\u00be\u00c2\u00c5\u00cd\u00d6\u00db\u00df\u00e2\u00e7\u00eb\u00f2"+
		"\u00fa\u0102\u010a\u010c\u0117\u011c\u0122\u0127\u012d\u012f\u0136\u013d"+
		"\u0146\u014c\u014e\u0153";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}