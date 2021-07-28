using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik.Antlr
{
    internal class ExpressionVisitor : QikTemplateBaseVisitor<IFunction>
    {
        private readonly ISymbolTable symbolTable;

        internal ExpressionVisitor(ISymbolTable symbolTable)
        {
            this.symbolTable = symbolTable ?? throw new ArgumentNullException($"{nameof(symbolTable)} cannot be null.");
        }

        public override IFunction VisitFuncDecl([NotNull] QikTemplateParser.FuncDeclContext context)
        {
            var id = context.VARIABLE().GetText();

            if (context.concatExpr() != null)
            {
                var concatenateFunc = GetConcatenateFunction(context.concatExpr());
                var expression =
                    new ExpressionSymbol(id, concatenateFunc);
                symbolTable.AddSymbol(expression);
            }

            else if (context.iffExpr() != null)
            {
                var function = VisitIffExpr(context.iffExpr());
                var expression =
                    new ExpressionSymbol(id, function);
                symbolTable.AddSymbol(expression);
            }
            
            else if (context.expr() != null)
            {
                var function = VisitExpr(context.expr());
                var expression = new ExpressionSymbol(id, function);
                symbolTable.AddSymbol(expression);
            }

            return null;
        }

        public override IFunction VisitIffExpr([NotNull] QikTemplateParser.IffExprContext context)
        {
            return GetIifFunction(context);
        }


        public override IFunction VisitFunc(QikTemplateParser.FuncContext context)
        {
            IFunction func = null;

            if (context.IDENTIFIER() != null)
            {
                string funcIdentifier = context.IDENTIFIER().GetText();
                List<IFunction> functionArguments = CreateArguments(context.funcArg());

                //TODO: Consider Injecting this. Does this need to be newed up every time? Don't think so...
                FunctionFactory functionFactory = new FunctionFactory(symbolTable);
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

        private IifFunction GetIifFunction(QikTemplateParser.IffExprContext context)
        {
            int line = context.Start.Line;
            int column = context.Start.Column;
            
            var comparison = context.compExpr();
            var expressions = context.expr();
            var iifs = context.iffExpr();


            var functions = new List<IFunction>();

            var compOperator = comparison.children[1].GetText();
            var operand1 = VisitExpr(comparison.expr()[0]);
            var operand2 = VisitExpr(comparison.expr()[1]);

            functions.Add(operand1);
            functions.Add(operand2);

            foreach (QikTemplateParser.ExprContext expr in expressions)
            {
                IFunction result = VisitExpr(expr);
                functions.Add(result);
            }

            foreach (QikTemplateParser.IffExprContext iif in iifs)
            {
                IFunction result = VisitIffExpr(iif);
                functions.Add(result);
            }         

            var iifFunc = new IifFunction("Iif", functions);
            iifFunc.SetOperator(compOperator);

            return iifFunc;
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
