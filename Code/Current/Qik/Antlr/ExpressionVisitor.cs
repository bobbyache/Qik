using System;
using System.Collections.Generic;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik.Antlr
{
    internal class ExpressionVisitor : QikTemplateBaseVisitor<IFunction>
    {
        private readonly IGlobalTable scopeTable;
        private readonly IErrorReport errorReport;

        internal ExpressionVisitor(IGlobalTable scopeTable, IErrorReport errorReport)
        {
            this.scopeTable = scopeTable ?? throw new ArgumentNullException($"{nameof(scopeTable)} cannot be null.");
            this.errorReport = errorReport ?? throw new ArgumentNullException($"{nameof(errorReport)} cannot be null.");
        }

        public override IFunction VisitExprDecl(QikTemplateParser.ExprDeclContext context)
        {
            var id = context.VARIABLE().GetText();

            var symbolArguments = new SymbolArguments(errorReport);
            symbolArguments.Process(context.declArgs());

            if (context.concatExpr() != null)
            {
                var concatenateFunc = GetConcatenateFunction(context.concatExpr());
                var expression =
                    new ExpressionSymbol(errorReport, id, symbolArguments.Title,
                        symbolArguments.IsPlaceholder, symbolArguments.IsVisibleToEditor, concatenateFunc);
                scopeTable.AddSymbol(expression);
            }
            else if (context.expr() != null)
            {
                var function = VisitExpr(context.expr());
                var expression = new ExpressionSymbol(errorReport, id, symbolArguments.Title,
                    symbolArguments.IsPlaceholder, symbolArguments.IsVisibleToEditor, function);
                scopeTable.AddSymbol(expression);
            }

            return null;
        }

        public override IFunction VisitFunc(QikTemplateParser.FuncContext context)
        {
            IFunction func = null;

            if (context.IDENTIFIER() != null)
            {
                string funcIdentifier = context.IDENTIFIER().GetText();
                List<IFunction> functionArguments = CreateArguments(context.funcArg());
                IFuncInfo funcInfo = new FuncInfo(funcIdentifier, context.Start.Line, context.Start.Column);

                //TODO: Consider Injecting this. Does this need to be newed up every time? Don't think so...
                FunctionFactory functionFactory = new FunctionFactory(scopeTable);
                func = functionFactory.GetFunction(funcIdentifier, funcInfo, functionArguments);
            }
            return func;
        }

        public override IFunction VisitExpr(QikTemplateParser.ExprContext context)
        {
            int line = context.Start.Line;
            int column = context.Start.Column;

            if (context.STRING() != null)
            {
                FuncInfo funcInfo = new FuncInfo("String", line, column);
                return new TextFunction(funcInfo, scopeTable, Common.StripOuterQuotes(context.STRING().GetText()));
            }

            else if (context.VARIABLE() != null)
            {
                FuncInfo funcInfo = new FuncInfo("Variable", line, column);
                return new VariableFunction(funcInfo, scopeTable, context.VARIABLE().GetText());
            }

            else if (context.CONST() != null)
            {
                string constantText = context.CONST().GetText();
                if (constantText == "NEWLINE")
                    return new NewlineFunction(new FuncInfo("Constant", line, column), scopeTable);
                else
                    return new ConstantFunction(new FuncInfo("Constant", line, column), scopeTable, context.CONST().GetText());
            }

            else if (context.INT() != null)
                return new IntegerFunction(new FuncInfo("Int", line, column), scopeTable, context.INT().GetText());

            else if (context.FLOAT() != null)
                return new FloatFunction(new FuncInfo("Float", line, column), scopeTable, context.FLOAT().GetText());

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

        private ConcatenateFunction GetConcatenateFunction(QikTemplateParser.ConcatExprContext context)
        {
            int line = context.Start.Line;
            int column = context.Start.Column;

            ConcatenateFunction concatenateFunc = new ConcatenateFunction(new FuncInfo("Concatenation", line, column), this.scopeTable);

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
