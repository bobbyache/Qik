using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik.Antlr
{
    internal class ExpressionVisitor : QikTemplateBaseVisitor<IFunction>
    {
        private readonly ISymbolTable symbolTable;
        private readonly IFunctionFactory functionFactory;

        internal ExpressionVisitor(ISymbolTable symbolTable, IFunctionFactory functionFactory)
        {
            this.functionFactory = functionFactory ?? throw new ArgumentNullException($"{nameof(functionFactory)} cannot be null.");
            this.symbolTable = symbolTable ?? throw new ArgumentNullException($"{nameof(symbolTable)} cannot be null.");
        }

        public override IFunction VisitFuncDecl([NotNull] QikTemplateParser.FuncDeclContext context)
        {
            var id = context.VARIABLE().GetText();

            if (context.stat() != null)
            {
                var func = GetStatementFunction(context.stat());
                var expression =
                    new ExpressionSymbol(id, func);
                symbolTable.AddSymbol(expression);
            }

            else if (context.switchExpr() != null)
            {
                var function = VisitSwitchExpr(context.switchExpr());
                var expression =
                    new ExpressionSymbol(id, function);
                symbolTable.AddSymbol(expression);
            }
            
            return null;
        }

        public override IFunction VisitIffExpr([NotNull] QikTemplateParser.IffExprContext context)
        {
            return GetIifFunction(context);
        }

        public override IFunction VisitSwitchExpr([NotNull] QikTemplateParser.SwitchExprContext context)
        {
            return GetSwitchFunction(context);
        }

        public override IFunction VisitFunc(QikTemplateParser.FuncContext context)
        {
            IFunction func = null;

            if (context.IDENTIFIER() != null)
            {
                string funcIdentifier = context.IDENTIFIER().GetText();
                List<IFunction> functionArguments = CreateArguments(context.funcArg());

                func = functionFactory.GetFunction(funcIdentifier, functionArguments);
            }
            return func;
        }

        public override IFunction VisitExpr(QikTemplateParser.ExprContext context)
        {
            int line = context.Start.Line;
            int column = context.Start.Column;

            if (context.STRING() != null)
            {
                return new TextFunction("String", context.STRING().GetText().StripOuterQuotes());
            }

            else if (context.VARIABLE() != null)
            {
                return new VariableFunction("Variable", symbolTable, context.VARIABLE().GetText());
            }

            else if (context.CONST() != null)
            {
                string constantText = context.CONST().GetText();
                if (constantText == "NEWLINE")
                    return new NewlineFunction("Constant");
                else
                    return new ConstantFunction("Constant", context.CONST().GetText());
            }

            else if (context.INT() != null)
                return new IntegerFunction("Int", context.INT().GetText());

            else if (context.FLOAT() != null)
                return new FloatFunction("Float", context.FLOAT().GetText());

            // recurse...
            else if (context.func() != null)
                return VisitFunc(context.func());

            else
                return null;
        }

        private List<IFunction> CreateArguments(IReadOnlyList<QikTemplateParser.FuncArgContext> funcArgs)
        {
            List<IFunction> functionArguments = new List<IFunction>();

            foreach (QikTemplateParser.FuncArgContext funcArg in funcArgs)
            {
                QikTemplateParser.ConcatExprContext concatExpr = funcArg.concatExpr();
                QikTemplateParser.ExprContext expr = funcArg.expr();

                if (concatExpr != null)
                {
                    ConcatenateFunction concatenateFunc = GetConcatenateFunction(concatExpr);
                    functionArguments.Add(concatenateFunc);
                }
                else if (expr != null)
                {
                    IFunction function = VisitExpr(expr);
                    functionArguments.Add(function);
                }
            }
            return functionArguments;
        }

        private SwitchFunction GetSwitchFunction(QikTemplateParser.SwitchExprContext context)
        {
            var subjectFunction = VisitExpr(context.switchStat().expr());

            var caseFuncs = new Dictionary<string, IFunction>();

            foreach (var possibleCase in context.caseStat())
            {
                var testVal = possibleCase.STRING().GetText().StripOuterQuotes();
                caseFuncs.Add(testVal, GetStatementFunction(possibleCase.stat()));
            }

            IFunction elseFunction = GetStatementFunction(context.elseStat().stat());

            return new SwitchFunction("SwitchFunction", subjectFunction, caseFuncs, elseFunction);
        }

        private IifFunction GetIifFunction(QikTemplateParser.IffExprContext context)
        {
            int line = context.Start.Line;
            int column = context.Start.Column;

            var comparison = context.compExpr();
            var compOperator = comparison.children[1].GetText();
            var leftOperand = VisitExpr(comparison.expr()[0]);
            var rightOperand = VisitExpr(comparison.expr()[1]);

            IFunction trueFunc = GetStatementFunction(context.iffTrueStat().stat());
            IFunction falseFunc = GetStatementFunction(context.iffFalseStat().stat());

            return new IifFunction("Iif", leftOperand, rightOperand, compOperator, trueFunc, falseFunc);
        }

        private IFunction GetStatementFunction(QikTemplateParser.StatContext context)
        {
            IFunction statementFunction = null;

            if (context.expr() is not null)
            {
                statementFunction = VisitExpr(context.expr());
            }
            else if (context.iffExpr() is not null)
            {
                statementFunction = VisitIffExpr(context.iffExpr());
            }
            else if (context.concatExpr() is not null)
            {
                statementFunction = GetConcatenateFunction(context.concatExpr());
            }

            return statementFunction;
        }

        private ConcatenateFunction GetConcatenateFunction(QikTemplateParser.ConcatExprContext context)
        {
            int line = context.Start.Line;
            int column = context.Start.Column;
            

            ConcatenateFunction concatenateFunc = new ConcatenateFunction("Concatenation");

            IReadOnlyList<QikTemplateParser.ExprContext> expressions = context.expr();

            foreach (QikTemplateParser.ExprContext expr in expressions)
            {
                IFunction result = VisitExpr(expr);
                concatenateFunc.AddFunction(result);
            }

            return concatenateFunc;
        }
    }
}
