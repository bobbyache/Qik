//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Code\bobbyache\Qik\Code\Current\QikAntlr\QikTemplate.g4 by ANTLR 4.9.2

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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class QikTemplateLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, CONST=23, STRING=24, 
		IDENTIFIER=25, VARIABLE=26, FLOAT=27, INT=28, WS=29, COMMENT=30, LINE_COMMENT=31;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "CONST", "STRING", "IDENTIFIER", 
		"VARIABLE", "FLOAT", "INT", "LETTER", "DIGIT", "WS", "COMMENT", "LINE_COMMENT"
	};


	public QikTemplateLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public QikTemplateLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'=>'", "';'", "'['", "','", "']'", "'='", "'title'", "'type'", 
		"'=='", "'!='", "'+'", "'?'", "':'", "'if'", "'then'", "'else if'", "'switch'", 
		"'case'", "'else'", "'()'", "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, "CONST", 
		"STRING", "IDENTIFIER", "VARIABLE", "FLOAT", "INT", "WS", "COMMENT", "LINE_COMMENT"
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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static QikTemplateLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '!', '\xF8', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', 
		'\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', 
		'\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', 
		'\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x5', '\x18', '\xA1', '\n', 
		'\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\a', 
		'\x19', '\xA7', '\n', '\x19', '\f', '\x19', '\xE', '\x19', '\xAA', '\v', 
		'\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1A', '\a', '\x1A', '\xB1', '\n', '\x1A', '\f', '\x1A', '\xE', '\x1A', 
		'\xB4', '\v', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1B', '\a', '\x1B', '\xBA', '\n', '\x1B', '\f', '\x1B', '\xE', '\x1B', 
		'\xBD', '\v', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\a', 
		'\x1C', '\xC2', '\n', '\x1C', '\f', '\x1C', '\xE', '\x1C', '\xC5', '\v', 
		'\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x5', '\x1C', '\xC9', '\n', '\x1C', 
		'\x3', '\x1D', '\x6', '\x1D', '\xCC', '\n', '\x1D', '\r', '\x1D', '\xE', 
		'\x1D', '\xCD', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', 
		'\x3', ' ', '\x6', ' ', '\xD5', '\n', ' ', '\r', ' ', '\xE', ' ', '\xD6', 
		'\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '!', 
		'\a', '!', '\xDF', '\n', '!', '\f', '!', '\xE', '!', '\xE2', '\v', '!', 
		'\x3', '!', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '\"', 
		'\x3', '\"', '\x3', '\"', '\x3', '\"', '\a', '\"', '\xED', '\n', '\"', 
		'\f', '\"', '\xE', '\"', '\xF0', '\v', '\"', '\x3', '\"', '\x5', '\"', 
		'\xF3', '\n', '\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', 
		'\x3', '\xE0', '\x2', '#', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', 
		'\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', 
		'\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', 
		'\x1F', '\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', 
		'\x16', '+', '\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', 
		'\x1B', '\x35', '\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x2', '=', 
		'\x2', '?', '\x1F', '\x41', ' ', '\x43', '!', '\x3', '\x2', '\a', '\x3', 
		'\x2', '$', '$', '\x6', '\x2', '\x43', '\\', '\x61', '\x61', '\x63', '|', 
		'\x101', '\x101', '\x3', '\x2', '\x32', ';', '\x5', '\x2', '\v', '\f', 
		'\xE', '\xF', '\"', '\"', '\x4', '\x2', '\f', '\f', '\xF', '\xF', '\x2', 
		'\x104', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', 
		')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', '\x2', '\x33', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '?', '\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x3', '\x45', 
		'\x3', '\x2', '\x2', '\x2', '\x5', 'H', '\x3', '\x2', '\x2', '\x2', '\a', 
		'J', '\x3', '\x2', '\x2', '\x2', '\t', 'L', '\x3', '\x2', '\x2', '\x2', 
		'\v', 'N', '\x3', '\x2', '\x2', '\x2', '\r', 'P', '\x3', '\x2', '\x2', 
		'\x2', '\xF', 'R', '\x3', '\x2', '\x2', '\x2', '\x11', 'X', '\x3', '\x2', 
		'\x2', '\x2', '\x13', ']', '\x3', '\x2', '\x2', '\x2', '\x15', '`', '\x3', 
		'\x2', '\x2', '\x2', '\x17', '\x63', '\x3', '\x2', '\x2', '\x2', '\x19', 
		'\x65', '\x3', '\x2', '\x2', '\x2', '\x1B', 'g', '\x3', '\x2', '\x2', 
		'\x2', '\x1D', 'i', '\x3', '\x2', '\x2', '\x2', '\x1F', 'l', '\x3', '\x2', 
		'\x2', '\x2', '!', 'q', '\x3', '\x2', '\x2', '\x2', '#', 'y', '\x3', '\x2', 
		'\x2', '\x2', '%', '\x80', '\x3', '\x2', '\x2', '\x2', '\'', '\x85', '\x3', 
		'\x2', '\x2', '\x2', ')', '\x8A', '\x3', '\x2', '\x2', '\x2', '+', '\x8D', 
		'\x3', '\x2', '\x2', '\x2', '-', '\x8F', '\x3', '\x2', '\x2', '\x2', '/', 
		'\xA0', '\x3', '\x2', '\x2', '\x2', '\x31', '\xA2', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\xAD', '\x3', '\x2', '\x2', '\x2', '\x35', '\xB5', '\x3', 
		'\x2', '\x2', '\x2', '\x37', '\xC8', '\x3', '\x2', '\x2', '\x2', '\x39', 
		'\xCB', '\x3', '\x2', '\x2', '\x2', ';', '\xCF', '\x3', '\x2', '\x2', 
		'\x2', '=', '\xD1', '\x3', '\x2', '\x2', '\x2', '?', '\xD4', '\x3', '\x2', 
		'\x2', '\x2', '\x41', '\xDA', '\x3', '\x2', '\x2', '\x2', '\x43', '\xE8', 
		'\x3', '\x2', '\x2', '\x2', '\x45', '\x46', '\a', '?', '\x2', '\x2', '\x46', 
		'G', '\a', '@', '\x2', '\x2', 'G', '\x4', '\x3', '\x2', '\x2', '\x2', 
		'H', 'I', '\a', '=', '\x2', '\x2', 'I', '\x6', '\x3', '\x2', '\x2', '\x2', 
		'J', 'K', '\a', ']', '\x2', '\x2', 'K', '\b', '\x3', '\x2', '\x2', '\x2', 
		'L', 'M', '\a', '.', '\x2', '\x2', 'M', '\n', '\x3', '\x2', '\x2', '\x2', 
		'N', 'O', '\a', '_', '\x2', '\x2', 'O', '\f', '\x3', '\x2', '\x2', '\x2', 
		'P', 'Q', '\a', '?', '\x2', '\x2', 'Q', '\xE', '\x3', '\x2', '\x2', '\x2', 
		'R', 'S', '\a', 'v', '\x2', '\x2', 'S', 'T', '\a', 'k', '\x2', '\x2', 
		'T', 'U', '\a', 'v', '\x2', '\x2', 'U', 'V', '\a', 'n', '\x2', '\x2', 
		'V', 'W', '\a', 'g', '\x2', '\x2', 'W', '\x10', '\x3', '\x2', '\x2', '\x2', 
		'X', 'Y', '\a', 'v', '\x2', '\x2', 'Y', 'Z', '\a', '{', '\x2', '\x2', 
		'Z', '[', '\a', 'r', '\x2', '\x2', '[', '\\', '\a', 'g', '\x2', '\x2', 
		'\\', '\x12', '\x3', '\x2', '\x2', '\x2', ']', '^', '\a', '?', '\x2', 
		'\x2', '^', '_', '\a', '?', '\x2', '\x2', '_', '\x14', '\x3', '\x2', '\x2', 
		'\x2', '`', '\x61', '\a', '#', '\x2', '\x2', '\x61', '\x62', '\a', '?', 
		'\x2', '\x2', '\x62', '\x16', '\x3', '\x2', '\x2', '\x2', '\x63', '\x64', 
		'\a', '-', '\x2', '\x2', '\x64', '\x18', '\x3', '\x2', '\x2', '\x2', '\x65', 
		'\x66', '\a', '\x41', '\x2', '\x2', '\x66', '\x1A', '\x3', '\x2', '\x2', 
		'\x2', 'g', 'h', '\a', '<', '\x2', '\x2', 'h', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', 'i', 'j', '\a', 'k', '\x2', '\x2', 'j', 'k', '\a', 'h', '\x2', 
		'\x2', 'k', '\x1E', '\x3', '\x2', '\x2', '\x2', 'l', 'm', '\a', 'v', '\x2', 
		'\x2', 'm', 'n', '\a', 'j', '\x2', '\x2', 'n', 'o', '\a', 'g', '\x2', 
		'\x2', 'o', 'p', '\a', 'p', '\x2', '\x2', 'p', ' ', '\x3', '\x2', '\x2', 
		'\x2', 'q', 'r', '\a', 'g', '\x2', '\x2', 'r', 's', '\a', 'n', '\x2', 
		'\x2', 's', 't', '\a', 'u', '\x2', '\x2', 't', 'u', '\a', 'g', '\x2', 
		'\x2', 'u', 'v', '\a', '\"', '\x2', '\x2', 'v', 'w', '\a', 'k', '\x2', 
		'\x2', 'w', 'x', '\a', 'h', '\x2', '\x2', 'x', '\"', '\x3', '\x2', '\x2', 
		'\x2', 'y', 'z', '\a', 'u', '\x2', '\x2', 'z', '{', '\a', 'y', '\x2', 
		'\x2', '{', '|', '\a', 'k', '\x2', '\x2', '|', '}', '\a', 'v', '\x2', 
		'\x2', '}', '~', '\a', '\x65', '\x2', '\x2', '~', '\x7F', '\a', 'j', '\x2', 
		'\x2', '\x7F', '$', '\x3', '\x2', '\x2', '\x2', '\x80', '\x81', '\a', 
		'\x65', '\x2', '\x2', '\x81', '\x82', '\a', '\x63', '\x2', '\x2', '\x82', 
		'\x83', '\a', 'u', '\x2', '\x2', '\x83', '\x84', '\a', 'g', '\x2', '\x2', 
		'\x84', '&', '\x3', '\x2', '\x2', '\x2', '\x85', '\x86', '\a', 'g', '\x2', 
		'\x2', '\x86', '\x87', '\a', 'n', '\x2', '\x2', '\x87', '\x88', '\a', 
		'u', '\x2', '\x2', '\x88', '\x89', '\a', 'g', '\x2', '\x2', '\x89', '(', 
		'\x3', '\x2', '\x2', '\x2', '\x8A', '\x8B', '\a', '*', '\x2', '\x2', '\x8B', 
		'\x8C', '\a', '+', '\x2', '\x2', '\x8C', '*', '\x3', '\x2', '\x2', '\x2', 
		'\x8D', '\x8E', '\a', '*', '\x2', '\x2', '\x8E', ',', '\x3', '\x2', '\x2', 
		'\x2', '\x8F', '\x90', '\a', '+', '\x2', '\x2', '\x90', '.', '\x3', '\x2', 
		'\x2', '\x2', '\x91', '\x92', '\a', 'V', '\x2', '\x2', '\x92', '\x93', 
		'\a', '\x43', '\x2', '\x2', '\x93', '\xA1', '\a', '\x44', '\x2', '\x2', 
		'\x94', '\x95', '\a', 'U', '\x2', '\x2', '\x95', '\x96', '\a', 'R', '\x2', 
		'\x2', '\x96', '\x97', '\a', '\x43', '\x2', '\x2', '\x97', '\x98', '\a', 
		'\x45', '\x2', '\x2', '\x98', '\xA1', '\a', 'G', '\x2', '\x2', '\x99', 
		'\x9A', '\a', 'P', '\x2', '\x2', '\x9A', '\x9B', '\a', 'G', '\x2', '\x2', 
		'\x9B', '\x9C', '\a', 'Y', '\x2', '\x2', '\x9C', '\x9D', '\a', 'N', '\x2', 
		'\x2', '\x9D', '\x9E', '\a', 'K', '\x2', '\x2', '\x9E', '\x9F', '\a', 
		'P', '\x2', '\x2', '\x9F', '\xA1', '\a', 'G', '\x2', '\x2', '\xA0', '\x91', 
		'\x3', '\x2', '\x2', '\x2', '\xA0', '\x94', '\x3', '\x2', '\x2', '\x2', 
		'\xA0', '\x99', '\x3', '\x2', '\x2', '\x2', '\xA1', '\x30', '\x3', '\x2', 
		'\x2', '\x2', '\xA2', '\xA8', '\a', '$', '\x2', '\x2', '\xA3', '\xA4', 
		'\a', '$', '\x2', '\x2', '\xA4', '\xA7', '\a', '$', '\x2', '\x2', '\xA5', 
		'\xA7', '\n', '\x2', '\x2', '\x2', '\xA6', '\xA3', '\x3', '\x2', '\x2', 
		'\x2', '\xA6', '\xA5', '\x3', '\x2', '\x2', '\x2', '\xA7', '\xAA', '\x3', 
		'\x2', '\x2', '\x2', '\xA8', '\xA6', '\x3', '\x2', '\x2', '\x2', '\xA8', 
		'\xA9', '\x3', '\x2', '\x2', '\x2', '\xA9', '\xAB', '\x3', '\x2', '\x2', 
		'\x2', '\xAA', '\xA8', '\x3', '\x2', '\x2', '\x2', '\xAB', '\xAC', '\a', 
		'$', '\x2', '\x2', '\xAC', '\x32', '\x3', '\x2', '\x2', '\x2', '\xAD', 
		'\xB2', '\x5', ';', '\x1E', '\x2', '\xAE', '\xB1', '\x5', ';', '\x1E', 
		'\x2', '\xAF', '\xB1', '\x5', '=', '\x1F', '\x2', '\xB0', '\xAE', '\x3', 
		'\x2', '\x2', '\x2', '\xB0', '\xAF', '\x3', '\x2', '\x2', '\x2', '\xB1', 
		'\xB4', '\x3', '\x2', '\x2', '\x2', '\xB2', '\xB0', '\x3', '\x2', '\x2', 
		'\x2', '\xB2', '\xB3', '\x3', '\x2', '\x2', '\x2', '\xB3', '\x34', '\x3', 
		'\x2', '\x2', '\x2', '\xB4', '\xB2', '\x3', '\x2', '\x2', '\x2', '\xB5', 
		'\xB6', '\a', '\x42', '\x2', '\x2', '\xB6', '\xBB', '\x5', ';', '\x1E', 
		'\x2', '\xB7', '\xBA', '\x5', ';', '\x1E', '\x2', '\xB8', '\xBA', '\x5', 
		'=', '\x1F', '\x2', '\xB9', '\xB7', '\x3', '\x2', '\x2', '\x2', '\xB9', 
		'\xB8', '\x3', '\x2', '\x2', '\x2', '\xBA', '\xBD', '\x3', '\x2', '\x2', 
		'\x2', '\xBB', '\xB9', '\x3', '\x2', '\x2', '\x2', '\xBB', '\xBC', '\x3', 
		'\x2', '\x2', '\x2', '\xBC', '\x36', '\x3', '\x2', '\x2', '\x2', '\xBD', 
		'\xBB', '\x3', '\x2', '\x2', '\x2', '\xBE', '\xBF', '\x5', '\x39', '\x1D', 
		'\x2', '\xBF', '\xC3', '\a', '\x30', '\x2', '\x2', '\xC0', '\xC2', '\x5', 
		'=', '\x1F', '\x2', '\xC1', '\xC0', '\x3', '\x2', '\x2', '\x2', '\xC2', 
		'\xC5', '\x3', '\x2', '\x2', '\x2', '\xC3', '\xC1', '\x3', '\x2', '\x2', 
		'\x2', '\xC3', '\xC4', '\x3', '\x2', '\x2', '\x2', '\xC4', '\xC9', '\x3', 
		'\x2', '\x2', '\x2', '\xC5', '\xC3', '\x3', '\x2', '\x2', '\x2', '\xC6', 
		'\xC7', '\a', '\x30', '\x2', '\x2', '\xC7', '\xC9', '\x5', '\x39', '\x1D', 
		'\x2', '\xC8', '\xBE', '\x3', '\x2', '\x2', '\x2', '\xC8', '\xC6', '\x3', 
		'\x2', '\x2', '\x2', '\xC9', '\x38', '\x3', '\x2', '\x2', '\x2', '\xCA', 
		'\xCC', '\x5', '=', '\x1F', '\x2', '\xCB', '\xCA', '\x3', '\x2', '\x2', 
		'\x2', '\xCC', '\xCD', '\x3', '\x2', '\x2', '\x2', '\xCD', '\xCB', '\x3', 
		'\x2', '\x2', '\x2', '\xCD', '\xCE', '\x3', '\x2', '\x2', '\x2', '\xCE', 
		':', '\x3', '\x2', '\x2', '\x2', '\xCF', '\xD0', '\t', '\x3', '\x2', '\x2', 
		'\xD0', '<', '\x3', '\x2', '\x2', '\x2', '\xD1', '\xD2', '\t', '\x4', 
		'\x2', '\x2', '\xD2', '>', '\x3', '\x2', '\x2', '\x2', '\xD3', '\xD5', 
		'\t', '\x5', '\x2', '\x2', '\xD4', '\xD3', '\x3', '\x2', '\x2', '\x2', 
		'\xD5', '\xD6', '\x3', '\x2', '\x2', '\x2', '\xD6', '\xD4', '\x3', '\x2', 
		'\x2', '\x2', '\xD6', '\xD7', '\x3', '\x2', '\x2', '\x2', '\xD7', '\xD8', 
		'\x3', '\x2', '\x2', '\x2', '\xD8', '\xD9', '\b', ' ', '\x2', '\x2', '\xD9', 
		'@', '\x3', '\x2', '\x2', '\x2', '\xDA', '\xDB', '\a', '\x31', '\x2', 
		'\x2', '\xDB', '\xDC', '\a', ',', '\x2', '\x2', '\xDC', '\xE0', '\x3', 
		'\x2', '\x2', '\x2', '\xDD', '\xDF', '\v', '\x2', '\x2', '\x2', '\xDE', 
		'\xDD', '\x3', '\x2', '\x2', '\x2', '\xDF', '\xE2', '\x3', '\x2', '\x2', 
		'\x2', '\xE0', '\xE1', '\x3', '\x2', '\x2', '\x2', '\xE0', '\xDE', '\x3', 
		'\x2', '\x2', '\x2', '\xE1', '\xE3', '\x3', '\x2', '\x2', '\x2', '\xE2', 
		'\xE0', '\x3', '\x2', '\x2', '\x2', '\xE3', '\xE4', '\a', ',', '\x2', 
		'\x2', '\xE4', '\xE5', '\a', '\x31', '\x2', '\x2', '\xE5', '\xE6', '\x3', 
		'\x2', '\x2', '\x2', '\xE6', '\xE7', '\b', '!', '\x2', '\x2', '\xE7', 
		'\x42', '\x3', '\x2', '\x2', '\x2', '\xE8', '\xE9', '\a', '\x31', '\x2', 
		'\x2', '\xE9', '\xEA', '\a', '\x31', '\x2', '\x2', '\xEA', '\xEE', '\x3', 
		'\x2', '\x2', '\x2', '\xEB', '\xED', '\n', '\x6', '\x2', '\x2', '\xEC', 
		'\xEB', '\x3', '\x2', '\x2', '\x2', '\xED', '\xF0', '\x3', '\x2', '\x2', 
		'\x2', '\xEE', '\xEC', '\x3', '\x2', '\x2', '\x2', '\xEE', '\xEF', '\x3', 
		'\x2', '\x2', '\x2', '\xEF', '\xF2', '\x3', '\x2', '\x2', '\x2', '\xF0', 
		'\xEE', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xF3', '\a', '\xF', '\x2', 
		'\x2', '\xF2', '\xF1', '\x3', '\x2', '\x2', '\x2', '\xF2', '\xF3', '\x3', 
		'\x2', '\x2', '\x2', '\xF3', '\xF4', '\x3', '\x2', '\x2', '\x2', '\xF4', 
		'\xF5', '\a', '\f', '\x2', '\x2', '\xF5', '\xF6', '\x3', '\x2', '\x2', 
		'\x2', '\xF6', '\xF7', '\b', '\"', '\x2', '\x2', '\xF7', '\x44', '\x3', 
		'\x2', '\x2', '\x2', '\x11', '\x2', '\xA0', '\xA6', '\xA8', '\xB0', '\xB2', 
		'\xB9', '\xBB', '\xC3', '\xC8', '\xCD', '\xD6', '\xE0', '\xEE', '\xF2', 
		'\x3', '\x2', '\x3', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace CygSoft.Qik.Antlr
