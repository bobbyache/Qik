using System;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik
{
    public class ExpressionSymbol : BaseSymbol, IExpression
    {
        private readonly IFunction func;

        private readonly IErrorReport errorReport;

        public ExpressionSymbol(IErrorReport errorReport, string symbol,
            IFunction func)
            : base(symbol)
        {
            this.func = func ?? throw new ArgumentNullException($"{nameof(func)} cannot be null.");
            this.errorReport = errorReport ?? throw new ArgumentNullException($"{nameof(errorReport)} cannot be null.");
        }

        public override string Value => func.Execute(errorReport);
    }
}
