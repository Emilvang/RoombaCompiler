// Generated from Grammar.g4 by ANTLR 4.7.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class GrammarLexer extends Lexer {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "T__10", "T__11", "ADDARRAY", "AND", "OR", "LT", "GT", "GTEQ", 
			"LTEQ", "NEQ", "EQ", "INTDECL", "FLOATDECL", "BOOLDECL", "LISTDECL", 
			"VOID", "IF", "ELSEIF", "ELSE", "WHILE", "FOR", "DIGIT", "CHARACTER", 
			"MUL", "DIV", "ADD", "SUB", "BOOL", "IDENTIFIER", "INT", "FLOAT", "COMMENT", 
			"WS"
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


	public GrammarLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Grammar.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2+\u011f\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3"+
		"\7\3\7\3\b\3\b\3\t\3\t\3\n\3\n\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f"+
		"\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3"+
		"\17\3\17\5\17\u008c\n\17\3\20\3\20\3\20\3\20\5\20\u0092\n\20\3\21\3\21"+
		"\3\22\3\22\3\23\3\23\3\23\3\24\3\24\3\24\3\25\3\25\3\25\3\26\3\26\3\26"+
		"\3\27\3\27\3\27\3\27\3\30\3\30\3\30\3\30\3\30\3\30\3\31\3\31\3\31\3\31"+
		"\3\31\3\32\3\32\3\32\3\33\3\33\3\33\3\33\3\33\3\34\3\34\3\34\3\35\3\35"+
		"\3\35\3\35\3\35\3\35\3\35\3\36\3\36\3\36\3\36\3\36\3\37\3\37\3\37\3\37"+
		"\3\37\3\37\3 \3 \3 \3 \3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3"+
		"\'\3\'\3\'\3\'\3\'\3\'\3\'\5\'\u00e9\n\'\3(\6(\u00ec\n(\r(\16(\u00ed\3"+
		"(\3(\7(\u00f2\n(\f(\16(\u00f5\13(\3)\5)\u00f8\n)\3)\6)\u00fb\n)\r)\16"+
		")\u00fc\3*\5*\u0100\n*\3*\6*\u0103\n*\r*\16*\u0104\3*\3*\6*\u0109\n*\r"+
		"*\16*\u010a\5*\u010d\n*\3+\3+\7+\u0111\n+\f+\16+\u0114\13+\3+\3+\3+\3"+
		"+\3,\3,\5,\u011c\n,\3,\3,\3\u0112\2-\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21"+
		"\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30"+
		"/\31\61\32\63\33\65\34\67\359\36;\37= ?!A\2C\2E\"G#I$K%M&O\'Q(S)U*W+\3"+
		"\2\4\4\2C\\c|\5\2\13\f\17\17\"\"\2\u012a\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3"+
		"\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2"+
		"\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35"+
		"\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)"+
		"\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2"+
		"\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2"+
		"E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2Q\3"+
		"\2\2\2\2S\3\2\2\2\2U\3\2\2\2\2W\3\2\2\2\3Y\3\2\2\2\5a\3\2\2\2\7c\3\2\2"+
		"\2\te\3\2\2\2\13g\3\2\2\2\ri\3\2\2\2\17k\3\2\2\2\21m\3\2\2\2\23o\3\2\2"+
		"\2\25q\3\2\2\2\27t\3\2\2\2\31z\3\2\2\2\33\u0081\3\2\2\2\35\u008b\3\2\2"+
		"\2\37\u0091\3\2\2\2!\u0093\3\2\2\2#\u0095\3\2\2\2%\u0097\3\2\2\2\'\u009a"+
		"\3\2\2\2)\u009d\3\2\2\2+\u00a0\3\2\2\2-\u00a3\3\2\2\2/\u00a7\3\2\2\2\61"+
		"\u00ad\3\2\2\2\63\u00b2\3\2\2\2\65\u00b5\3\2\2\2\67\u00ba\3\2\2\29\u00bd"+
		"\3\2\2\2;\u00c4\3\2\2\2=\u00c9\3\2\2\2?\u00cf\3\2\2\2A\u00d3\3\2\2\2C"+
		"\u00d5\3\2\2\2E\u00d7\3\2\2\2G\u00d9\3\2\2\2I\u00db\3\2\2\2K\u00dd\3\2"+
		"\2\2M\u00e8\3\2\2\2O\u00eb\3\2\2\2Q\u00f7\3\2\2\2S\u00ff\3\2\2\2U\u010e"+
		"\3\2\2\2W\u011b\3\2\2\2YZ\7R\2\2Z[\7t\2\2[\\\7q\2\2\\]\7i\2\2]^\7t\2\2"+
		"^_\7c\2\2_`\7o\2\2`\4\3\2\2\2ab\7}\2\2b\6\3\2\2\2cd\7\177\2\2d\b\3\2\2"+
		"\2ef\7?\2\2f\n\3\2\2\2gh\7]\2\2h\f\3\2\2\2ij\7.\2\2j\16\3\2\2\2kl\7_\2"+
		"\2l\20\3\2\2\2mn\7*\2\2n\22\3\2\2\2op\7+\2\2p\24\3\2\2\2qr\7v\2\2rs\7"+
		"q\2\2s\26\3\2\2\2tu\7r\2\2uv\7t\2\2vw\7k\2\2wx\7p\2\2xy\7v\2\2y\30\3\2"+
		"\2\2z{\7t\2\2{|\7g\2\2|}\7v\2\2}~\7w\2\2~\177\7t\2\2\177\u0080\7p\2\2"+
		"\u0080\32\3\2\2\2\u0081\u0082\7c\2\2\u0082\u0083\7f\2\2\u0083\u0084\7"+
		"f\2\2\u0084\34\3\2\2\2\u0085\u0086\7c\2\2\u0086\u0087\7p\2\2\u0087\u008c"+
		"\7f\2\2\u0088\u0089\7C\2\2\u0089\u008a\7P\2\2\u008a\u008c\7F\2\2\u008b"+
		"\u0085\3\2\2\2\u008b\u0088\3\2\2\2\u008c\36\3\2\2\2\u008d\u008e\7q\2\2"+
		"\u008e\u0092\7t\2\2\u008f\u0090\7Q\2\2\u0090\u0092\7T\2\2\u0091\u008d"+
		"\3\2\2\2\u0091\u008f\3\2\2\2\u0092 \3\2\2\2\u0093\u0094\7>\2\2\u0094\""+
		"\3\2\2\2\u0095\u0096\7@\2\2\u0096$\3\2\2\2\u0097\u0098\7@\2\2\u0098\u0099"+
		"\7?\2\2\u0099&\3\2\2\2\u009a\u009b\7>\2\2\u009b\u009c\7?\2\2\u009c(\3"+
		"\2\2\2\u009d\u009e\7#\2\2\u009e\u009f\7?\2\2\u009f*\3\2\2\2\u00a0\u00a1"+
		"\7?\2\2\u00a1\u00a2\7?\2\2\u00a2,\3\2\2\2\u00a3\u00a4\7k\2\2\u00a4\u00a5"+
		"\7p\2\2\u00a5\u00a6\7v\2\2\u00a6.\3\2\2\2\u00a7\u00a8\7h\2\2\u00a8\u00a9"+
		"\7n\2\2\u00a9\u00aa\7q\2\2\u00aa\u00ab\7c\2\2\u00ab\u00ac\7v\2\2\u00ac"+
		"\60\3\2\2\2\u00ad\u00ae\7d\2\2\u00ae\u00af\7q\2\2\u00af\u00b0\7q\2\2\u00b0"+
		"\u00b1\7n\2\2\u00b1\62\3\2\2\2\u00b2\u00b3\7]\2\2\u00b3\u00b4\7_\2\2\u00b4"+
		"\64\3\2\2\2\u00b5\u00b6\7x\2\2\u00b6\u00b7\7q\2\2\u00b7\u00b8\7k\2\2\u00b8"+
		"\u00b9\7f\2\2\u00b9\66\3\2\2\2\u00ba\u00bb\7k\2\2\u00bb\u00bc\7h\2\2\u00bc"+
		"8\3\2\2\2\u00bd\u00be\7g\2\2\u00be\u00bf\7n\2\2\u00bf\u00c0\7u\2\2\u00c0"+
		"\u00c1\7g\2\2\u00c1\u00c2\7k\2\2\u00c2\u00c3\7h\2\2\u00c3:\3\2\2\2\u00c4"+
		"\u00c5\7g\2\2\u00c5\u00c6\7n\2\2\u00c6\u00c7\7u\2\2\u00c7\u00c8\7g\2\2"+
		"\u00c8<\3\2\2\2\u00c9\u00ca\7y\2\2\u00ca\u00cb\7j\2\2\u00cb\u00cc\7k\2"+
		"\2\u00cc\u00cd\7n\2\2\u00cd\u00ce\7g\2\2\u00ce>\3\2\2\2\u00cf\u00d0\7"+
		"h\2\2\u00d0\u00d1\7q\2\2\u00d1\u00d2\7t\2\2\u00d2@\3\2\2\2\u00d3\u00d4"+
		"\4\62;\2\u00d4B\3\2\2\2\u00d5\u00d6\t\2\2\2\u00d6D\3\2\2\2\u00d7\u00d8"+
		"\7,\2\2\u00d8F\3\2\2\2\u00d9\u00da\7\61\2\2\u00daH\3\2\2\2\u00db\u00dc"+
		"\7-\2\2\u00dcJ\3\2\2\2\u00dd\u00de\7/\2\2\u00deL\3\2\2\2\u00df\u00e0\7"+
		"V\2\2\u00e0\u00e1\7t\2\2\u00e1\u00e2\7w\2\2\u00e2\u00e9\7g\2\2\u00e3\u00e4"+
		"\7H\2\2\u00e4\u00e5\7c\2\2\u00e5\u00e6\7n\2\2\u00e6\u00e7\7u\2\2\u00e7"+
		"\u00e9\7g\2\2\u00e8\u00df\3\2\2\2\u00e8\u00e3\3\2\2\2\u00e9N\3\2\2\2\u00ea"+
		"\u00ec\5C\"\2\u00eb\u00ea\3\2\2\2\u00ec\u00ed\3\2\2\2\u00ed\u00eb\3\2"+
		"\2\2\u00ed\u00ee\3\2\2\2\u00ee\u00f3\3\2\2\2\u00ef\u00f2\5C\"\2\u00f0"+
		"\u00f2\5A!\2\u00f1\u00ef\3\2\2\2\u00f1\u00f0\3\2\2\2\u00f2\u00f5\3\2\2"+
		"\2\u00f3\u00f1\3\2\2\2\u00f3\u00f4\3\2\2\2\u00f4P\3\2\2\2\u00f5\u00f3"+
		"\3\2\2\2\u00f6\u00f8\7/\2\2\u00f7\u00f6\3\2\2\2\u00f7\u00f8\3\2\2\2\u00f8"+
		"\u00fa\3\2\2\2\u00f9\u00fb\5A!\2\u00fa\u00f9\3\2\2\2\u00fb\u00fc\3\2\2"+
		"\2\u00fc\u00fa\3\2\2\2\u00fc\u00fd\3\2\2\2\u00fdR\3\2\2\2\u00fe\u0100"+
		"\7/\2\2\u00ff\u00fe\3\2\2\2\u00ff\u0100\3\2\2\2\u0100\u0102\3\2\2\2\u0101"+
		"\u0103\5A!\2\u0102\u0101\3\2\2\2\u0103\u0104\3\2\2\2\u0104\u0102\3\2\2"+
		"\2\u0104\u0105\3\2\2\2\u0105\u010c\3\2\2\2\u0106\u0108\7\60\2\2\u0107"+
		"\u0109\5A!\2\u0108\u0107\3\2\2\2\u0109\u010a\3\2\2\2\u010a\u0108\3\2\2"+
		"\2\u010a\u010b\3\2\2\2\u010b\u010d\3\2\2\2\u010c\u0106\3\2\2\2\u010c\u010d"+
		"\3\2\2\2\u010dT\3\2\2\2\u010e\u0112\7%\2\2\u010f\u0111\13\2\2\2\u0110"+
		"\u010f\3\2\2\2\u0111\u0114\3\2\2\2\u0112\u0113\3\2\2\2\u0112\u0110\3\2"+
		"\2\2\u0113\u0115\3\2\2\2\u0114\u0112\3\2\2\2\u0115\u0116\7%\2\2\u0116"+
		"\u0117\3\2\2\2\u0117\u0118\b+\2\2\u0118V\3\2\2\2\u0119\u011c\t\3\2\2\u011a"+
		"\u011c\5U+\2\u011b\u0119\3\2\2\2\u011b\u011a\3\2\2\2\u011c\u011d\3\2\2"+
		"\2\u011d\u011e\b,\3\2\u011eX\3\2\2\2\21\2\u008b\u0091\u00e8\u00ed\u00f1"+
		"\u00f3\u00f7\u00fc\u00ff\u0104\u010a\u010c\u0112\u011b\4\b\2\2\2\3\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}