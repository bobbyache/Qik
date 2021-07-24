//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Code\you\Qik\Code\Current\QikAntlr\QikTemplate.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace CygSoft.Qik.Antlr {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class QikTemplateParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, CONST=15, STRING=16, 
		IDENTIFIER=17, VARIABLE=18, FLOAT=19, INT=20, WS=21, COMMENT=22, LINE_COMMENT=23;
	public const int
		RULE_template = 0, RULE_input = 1, RULE_ctrlDecl = 2, RULE_textBox = 3, 
		RULE_exprDecl = 4, RULE_declArgs = 5, RULE_declArg = 6, RULE_expr = 7, 
		RULE_concatExpr = 8, RULE_func = 9, RULE_funcArg = 10;
	public static readonly string[] ruleNames = {
		"template", "input", "ctrlDecl", "textBox", "exprDecl", "declArgs", "declArg", 
		"expr", "concatExpr", "func", "funcArg"
	};

	private static readonly string[] _LiteralNames = {
		null, "'='", "';'", "'text'", "'['", "']'", "'expression'", "'{'", "'return'", 
		"'}'", "','", "'+'", "'()'", "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, "CONST", "STRING", "IDENTIFIER", "VARIABLE", "FLOAT", 
		"INT", "WS", "COMMENT", "LINE_COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "QikTemplate.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static QikTemplateParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public QikTemplateParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public QikTemplateParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class TemplateContext : ParserRuleContext {
		public InputContext[] input() {
			return GetRuleContexts<InputContext>();
		}
		public InputContext input(int i) {
			return GetRuleContext<InputContext>(i);
		}
		public CtrlDeclContext[] ctrlDecl() {
			return GetRuleContexts<CtrlDeclContext>();
		}
		public CtrlDeclContext ctrlDecl(int i) {
			return GetRuleContext<CtrlDeclContext>(i);
		}
		public ExprDeclContext[] exprDecl() {
			return GetRuleContexts<ExprDeclContext>();
		}
		public ExprDeclContext exprDecl(int i) {
			return GetRuleContext<ExprDeclContext>(i);
		}
		public TemplateContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_template; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterTemplate(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitTemplate(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTemplate(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TemplateContext template() {
		TemplateContext _localctx = new TemplateContext(Context, State);
		EnterRule(_localctx, 0, RULE_template);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 25;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				State = 25;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,0,Context) ) {
				case 1:
					{
					State = 22; input();
					}
					break;
				case 2:
					{
					State = 23; ctrlDecl();
					}
					break;
				case 3:
					{
					State = 24; exprDecl();
					}
					break;
				}
				}
				State = 27;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==VARIABLE );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class InputContext : ParserRuleContext {
		public ITerminalNode VARIABLE() { return GetToken(QikTemplateParser.VARIABLE, 0); }
		public ITerminalNode STRING() { return GetToken(QikTemplateParser.STRING, 0); }
		public InputContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_input; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterInput(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitInput(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInput(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public InputContext input() {
		InputContext _localctx = new InputContext(Context, State);
		EnterRule(_localctx, 2, RULE_input);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 29; Match(VARIABLE);
			State = 30; Match(T__0);
			State = 31; Match(STRING);
			State = 32; Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CtrlDeclContext : ParserRuleContext {
		public TextBoxContext textBox() {
			return GetRuleContext<TextBoxContext>(0);
		}
		public CtrlDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_ctrlDecl; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterCtrlDecl(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitCtrlDecl(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCtrlDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CtrlDeclContext ctrlDecl() {
		CtrlDeclContext _localctx = new CtrlDeclContext(Context, State);
		EnterRule(_localctx, 4, RULE_ctrlDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 34; textBox();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TextBoxContext : ParserRuleContext {
		public ITerminalNode VARIABLE() { return GetToken(QikTemplateParser.VARIABLE, 0); }
		public DeclArgsContext declArgs() {
			return GetRuleContext<DeclArgsContext>(0);
		}
		public TextBoxContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_textBox; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterTextBox(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitTextBox(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTextBox(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TextBoxContext textBox() {
		TextBoxContext _localctx = new TextBoxContext(Context, State);
		EnterRule(_localctx, 6, RULE_textBox);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 36; Match(VARIABLE);
			State = 37; Match(T__0);
			State = 38; Match(T__2);
			State = 39; Match(T__3);
			State = 40; declArgs();
			State = 41; Match(T__4);
			State = 42; Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprDeclContext : ParserRuleContext {
		public ITerminalNode VARIABLE() { return GetToken(QikTemplateParser.VARIABLE, 0); }
		public DeclArgsContext declArgs() {
			return GetRuleContext<DeclArgsContext>(0);
		}
		public ConcatExprContext concatExpr() {
			return GetRuleContext<ConcatExprContext>(0);
		}
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ExprDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_exprDecl; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterExprDecl(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitExprDecl(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExprDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprDeclContext exprDecl() {
		ExprDeclContext _localctx = new ExprDeclContext(Context, State);
		EnterRule(_localctx, 8, RULE_exprDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 44; Match(VARIABLE);
			State = 45; Match(T__0);
			State = 46; Match(T__5);
			State = 47; Match(T__3);
			State = 48; declArgs();
			State = 49; Match(T__4);
			State = 50; Match(T__6);
			State = 51; Match(T__7);
			State = 54;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				{
				State = 52; concatExpr();
				}
				break;
			case 2:
				{
				State = 53; expr();
				}
				break;
			}
			State = 56; Match(T__1);
			State = 57; Match(T__8);
			State = 58; Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DeclArgsContext : ParserRuleContext {
		public DeclArgContext[] declArg() {
			return GetRuleContexts<DeclArgContext>();
		}
		public DeclArgContext declArg(int i) {
			return GetRuleContext<DeclArgContext>(i);
		}
		public DeclArgsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_declArgs; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterDeclArgs(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitDeclArgs(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDeclArgs(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DeclArgsContext declArgs() {
		DeclArgsContext _localctx = new DeclArgsContext(Context, State);
		EnterRule(_localctx, 10, RULE_declArgs);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 60; declArg();
			State = 65;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__9) {
				{
				{
				State = 61; Match(T__9);
				State = 62; declArg();
				}
				}
				State = 67;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DeclArgContext : ParserRuleContext {
		public ITerminalNode IDENTIFIER() { return GetToken(QikTemplateParser.IDENTIFIER, 0); }
		public ITerminalNode STRING() { return GetToken(QikTemplateParser.STRING, 0); }
		public DeclArgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_declArg; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterDeclArg(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitDeclArg(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDeclArg(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DeclArgContext declArg() {
		DeclArgContext _localctx = new DeclArgContext(Context, State);
		EnterRule(_localctx, 12, RULE_declArg);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 68; Match(IDENTIFIER);
			State = 69; Match(T__0);
			State = 70; Match(STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public FuncContext func() {
			return GetRuleContext<FuncContext>(0);
		}
		public ITerminalNode STRING() { return GetToken(QikTemplateParser.STRING, 0); }
		public ITerminalNode VARIABLE() { return GetToken(QikTemplateParser.VARIABLE, 0); }
		public ITerminalNode INT() { return GetToken(QikTemplateParser.INT, 0); }
		public ITerminalNode FLOAT() { return GetToken(QikTemplateParser.FLOAT, 0); }
		public ITerminalNode CONST() { return GetToken(QikTemplateParser.CONST, 0); }
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		ExprContext _localctx = new ExprContext(Context, State);
		EnterRule(_localctx, 14, RULE_expr);
		try {
			State = 78;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case IDENTIFIER:
				EnterOuterAlt(_localctx, 1);
				{
				State = 72; func();
				}
				break;
			case STRING:
				EnterOuterAlt(_localctx, 2);
				{
				State = 73; Match(STRING);
				}
				break;
			case VARIABLE:
				EnterOuterAlt(_localctx, 3);
				{
				State = 74; Match(VARIABLE);
				}
				break;
			case INT:
				EnterOuterAlt(_localctx, 4);
				{
				State = 75; Match(INT);
				}
				break;
			case FLOAT:
				EnterOuterAlt(_localctx, 5);
				{
				State = 76; Match(FLOAT);
				}
				break;
			case CONST:
				EnterOuterAlt(_localctx, 6);
				{
				State = 77; Match(CONST);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ConcatExprContext : ParserRuleContext {
		public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public ConcatExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_concatExpr; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterConcatExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitConcatExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitConcatExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ConcatExprContext concatExpr() {
		ConcatExprContext _localctx = new ConcatExprContext(Context, State);
		EnterRule(_localctx, 16, RULE_concatExpr);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 80; expr();
			State = 83;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 81; Match(T__10);
				State = 82; expr();
				}
				}
				State = 85;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==T__10 );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncContext : ParserRuleContext {
		public ITerminalNode IDENTIFIER() { return GetToken(QikTemplateParser.IDENTIFIER, 0); }
		public FuncArgContext[] funcArg() {
			return GetRuleContexts<FuncArgContext>();
		}
		public FuncArgContext funcArg(int i) {
			return GetRuleContext<FuncArgContext>(i);
		}
		public FuncContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_func; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterFunc(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitFunc(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFunc(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncContext func() {
		FuncContext _localctx = new FuncContext(Context, State);
		EnterRule(_localctx, 18, RULE_func);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 87; Match(IDENTIFIER);
			State = 100;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__11:
				{
				State = 88; Match(T__11);
				}
				break;
			case T__12:
				{
				State = 89; Match(T__12);
				State = 90; funcArg();
				State = 95;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==T__9) {
					{
					{
					State = 91; Match(T__9);
					State = 92; funcArg();
					}
					}
					State = 97;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 98; Match(T__13);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncArgContext : ParserRuleContext {
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ConcatExprContext concatExpr() {
			return GetRuleContext<ConcatExprContext>(0);
		}
		public FuncArgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_funcArg; } }
		public override void EnterRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.EnterFuncArg(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IQikTemplateListener typedListener = listener as IQikTemplateListener;
			if (typedListener != null) typedListener.ExitFuncArg(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IQikTemplateVisitor<TResult> typedVisitor = visitor as IQikTemplateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncArg(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncArgContext funcArg() {
		FuncArgContext _localctx = new FuncArgContext(Context, State);
		EnterRule(_localctx, 20, RULE_funcArg);
		try {
			State = 104;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,8,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 102; expr();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 103; concatExpr();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x19', 'm', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x6', 
		'\x2', '\x1C', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '\x1D', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x5', 
		'\x6', '\x39', '\n', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\a', '\a', '\x42', 
		'\n', '\a', '\f', '\a', '\xE', '\a', '\x45', '\v', '\a', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x5', '\t', 'Q', '\n', '\t', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x6', '\n', 'V', '\n', '\n', '\r', 
		'\n', '\xE', '\n', 'W', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', 
		'\v', '\x3', '\v', '\x3', '\v', '\a', '\v', '`', '\n', '\v', '\f', '\v', 
		'\xE', '\v', '\x63', '\v', '\v', '\x3', '\v', '\x3', '\v', '\x5', '\v', 
		'g', '\n', '\v', '\x3', '\f', '\x3', '\f', '\x5', '\f', 'k', '\n', '\f', 
		'\x3', '\f', '\x2', '\x2', '\r', '\x2', '\x4', '\x6', '\b', '\n', '\f', 
		'\xE', '\x10', '\x12', '\x14', '\x16', '\x2', '\x2', '\x2', 'o', '\x2', 
		'\x1B', '\x3', '\x2', '\x2', '\x2', '\x4', '\x1F', '\x3', '\x2', '\x2', 
		'\x2', '\x6', '$', '\x3', '\x2', '\x2', '\x2', '\b', '&', '\x3', '\x2', 
		'\x2', '\x2', '\n', '.', '\x3', '\x2', '\x2', '\x2', '\f', '>', '\x3', 
		'\x2', '\x2', '\x2', '\xE', '\x46', '\x3', '\x2', '\x2', '\x2', '\x10', 
		'P', '\x3', '\x2', '\x2', '\x2', '\x12', 'R', '\x3', '\x2', '\x2', '\x2', 
		'\x14', 'Y', '\x3', '\x2', '\x2', '\x2', '\x16', 'j', '\x3', '\x2', '\x2', 
		'\x2', '\x18', '\x1C', '\x5', '\x4', '\x3', '\x2', '\x19', '\x1C', '\x5', 
		'\x6', '\x4', '\x2', '\x1A', '\x1C', '\x5', '\n', '\x6', '\x2', '\x1B', 
		'\x18', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1D', '\x3', 
		'\x2', '\x2', '\x2', '\x1D', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'\x1E', '\x3', '\x2', '\x2', '\x2', '\x1E', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', ' ', '\a', '\x14', '\x2', '\x2', ' ', '!', '\a', '\x3', 
		'\x2', '\x2', '!', '\"', '\a', '\x12', '\x2', '\x2', '\"', '#', '\a', 
		'\x4', '\x2', '\x2', '#', '\x5', '\x3', '\x2', '\x2', '\x2', '$', '%', 
		'\x5', '\b', '\x5', '\x2', '%', '\a', '\x3', '\x2', '\x2', '\x2', '&', 
		'\'', '\a', '\x14', '\x2', '\x2', '\'', '(', '\a', '\x3', '\x2', '\x2', 
		'(', ')', '\a', '\x5', '\x2', '\x2', ')', '*', '\a', '\x6', '\x2', '\x2', 
		'*', '+', '\x5', '\f', '\a', '\x2', '+', ',', '\a', '\a', '\x2', '\x2', 
		',', '-', '\a', '\x4', '\x2', '\x2', '-', '\t', '\x3', '\x2', '\x2', '\x2', 
		'.', '/', '\a', '\x14', '\x2', '\x2', '/', '\x30', '\a', '\x3', '\x2', 
		'\x2', '\x30', '\x31', '\a', '\b', '\x2', '\x2', '\x31', '\x32', '\a', 
		'\x6', '\x2', '\x2', '\x32', '\x33', '\x5', '\f', '\a', '\x2', '\x33', 
		'\x34', '\a', '\a', '\x2', '\x2', '\x34', '\x35', '\a', '\t', '\x2', '\x2', 
		'\x35', '\x38', '\a', '\n', '\x2', '\x2', '\x36', '\x39', '\x5', '\x12', 
		'\n', '\x2', '\x37', '\x39', '\x5', '\x10', '\t', '\x2', '\x38', '\x36', 
		'\x3', '\x2', '\x2', '\x2', '\x38', '\x37', '\x3', '\x2', '\x2', '\x2', 
		'\x39', ':', '\x3', '\x2', '\x2', '\x2', ':', ';', '\a', '\x4', '\x2', 
		'\x2', ';', '<', '\a', '\v', '\x2', '\x2', '<', '=', '\a', '\x4', '\x2', 
		'\x2', '=', '\v', '\x3', '\x2', '\x2', '\x2', '>', '\x43', '\x5', '\xE', 
		'\b', '\x2', '?', '@', '\a', '\f', '\x2', '\x2', '@', '\x42', '\x5', '\xE', 
		'\b', '\x2', '\x41', '?', '\x3', '\x2', '\x2', '\x2', '\x42', '\x45', 
		'\x3', '\x2', '\x2', '\x2', '\x43', '\x41', '\x3', '\x2', '\x2', '\x2', 
		'\x43', '\x44', '\x3', '\x2', '\x2', '\x2', '\x44', '\r', '\x3', '\x2', 
		'\x2', '\x2', '\x45', '\x43', '\x3', '\x2', '\x2', '\x2', '\x46', 'G', 
		'\a', '\x13', '\x2', '\x2', 'G', 'H', '\a', '\x3', '\x2', '\x2', 'H', 
		'I', '\a', '\x12', '\x2', '\x2', 'I', '\xF', '\x3', '\x2', '\x2', '\x2', 
		'J', 'Q', '\x5', '\x14', '\v', '\x2', 'K', 'Q', '\a', '\x12', '\x2', '\x2', 
		'L', 'Q', '\a', '\x14', '\x2', '\x2', 'M', 'Q', '\a', '\x16', '\x2', '\x2', 
		'N', 'Q', '\a', '\x15', '\x2', '\x2', 'O', 'Q', '\a', '\x11', '\x2', '\x2', 
		'P', 'J', '\x3', '\x2', '\x2', '\x2', 'P', 'K', '\x3', '\x2', '\x2', '\x2', 
		'P', 'L', '\x3', '\x2', '\x2', '\x2', 'P', 'M', '\x3', '\x2', '\x2', '\x2', 
		'P', 'N', '\x3', '\x2', '\x2', '\x2', 'P', 'O', '\x3', '\x2', '\x2', '\x2', 
		'Q', '\x11', '\x3', '\x2', '\x2', '\x2', 'R', 'U', '\x5', '\x10', '\t', 
		'\x2', 'S', 'T', '\a', '\r', '\x2', '\x2', 'T', 'V', '\x5', '\x10', '\t', 
		'\x2', 'U', 'S', '\x3', '\x2', '\x2', '\x2', 'V', 'W', '\x3', '\x2', '\x2', 
		'\x2', 'W', 'U', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\x3', '\x2', '\x2', 
		'\x2', 'X', '\x13', '\x3', '\x2', '\x2', '\x2', 'Y', '\x66', '\a', '\x13', 
		'\x2', '\x2', 'Z', 'g', '\a', '\xE', '\x2', '\x2', '[', '\\', '\a', '\xF', 
		'\x2', '\x2', '\\', '\x61', '\x5', '\x16', '\f', '\x2', ']', '^', '\a', 
		'\f', '\x2', '\x2', '^', '`', '\x5', '\x16', '\f', '\x2', '_', ']', '\x3', 
		'\x2', '\x2', '\x2', '`', '\x63', '\x3', '\x2', '\x2', '\x2', '\x61', 
		'_', '\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\x3', '\x2', '\x2', 
		'\x2', '\x62', '\x64', '\x3', '\x2', '\x2', '\x2', '\x63', '\x61', '\x3', 
		'\x2', '\x2', '\x2', '\x64', '\x65', '\a', '\x10', '\x2', '\x2', '\x65', 
		'g', '\x3', '\x2', '\x2', '\x2', '\x66', 'Z', '\x3', '\x2', '\x2', '\x2', 
		'\x66', '[', '\x3', '\x2', '\x2', '\x2', 'g', '\x15', '\x3', '\x2', '\x2', 
		'\x2', 'h', 'k', '\x5', '\x10', '\t', '\x2', 'i', 'k', '\x5', '\x12', 
		'\n', '\x2', 'j', 'h', '\x3', '\x2', '\x2', '\x2', 'j', 'i', '\x3', '\x2', 
		'\x2', '\x2', 'k', '\x17', '\x3', '\x2', '\x2', '\x2', '\v', '\x1B', '\x1D', 
		'\x38', '\x43', 'P', 'W', '\x61', '\x66', 'j',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace CygSoft.Qik.Antlr
