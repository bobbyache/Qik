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
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="QikTemplateParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IQikTemplateVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.template"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTemplate([NotNull] QikTemplateParser.TemplateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.inputDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInputDecl([NotNull] QikTemplateParser.InputDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.uiWidget"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUiWidget([NotNull] QikTemplateParser.UiWidgetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.uiWidgetProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUiWidgetProperty([NotNull] QikTemplateParser.UiWidgetPropertyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.uiWidgetKey"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUiWidgetKey([NotNull] QikTemplateParser.UiWidgetKeyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.funcDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncDecl([NotNull] QikTemplateParser.FuncDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStat([NotNull] QikTemplateParser.StatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] QikTemplateParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.compExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompExpr([NotNull] QikTemplateParser.CompExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.concatExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConcatExpr([NotNull] QikTemplateParser.ConcatExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.iffExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIffExpr([NotNull] QikTemplateParser.IffExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.iffTrueStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIffTrueStat([NotNull] QikTemplateParser.IffTrueStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.iffFalseStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIffFalseStat([NotNull] QikTemplateParser.IffFalseStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.ifExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfExpr([NotNull] QikTemplateParser.IfExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.ifStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStat([NotNull] QikTemplateParser.IfStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.elseIfStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseIfStat([NotNull] QikTemplateParser.ElseIfStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.switchExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitchExpr([NotNull] QikTemplateParser.SwitchExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.switchStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitchStat([NotNull] QikTemplateParser.SwitchStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.caseStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseStat([NotNull] QikTemplateParser.CaseStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.elseStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseStat([NotNull] QikTemplateParser.ElseStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc([NotNull] QikTemplateParser.FuncContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="QikTemplateParser.funcArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncArg([NotNull] QikTemplateParser.FuncArgContext context);
}
} // namespace CygSoft.Qik.Antlr
