using System;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik
{
    public class ExpressionSymbol : BaseSymbol, IExpression
    {
        private readonly IFunction func;

        // TODO: This was a convenience for the old windows property grid. Think it's not really necessary although part of the language. Investigate.
        public bool IsVisibleToEditor { get; }
        private readonly IErrorReport errorReport;

        public ExpressionSymbol(IErrorReport errorReport, string symbol, string title,
            bool isPlaceholder, bool isVisibleToEditor, IFunction func)
            : base(symbol, title, isPlaceholder)
        {
            this.func = func ?? throw new ArgumentNullException($"{nameof(func)} cannot be null.");
            this.errorReport = errorReport ?? throw new ArgumentNullException($"{nameof(errorReport)} cannot be null.");
            IsVisibleToEditor = isVisibleToEditor;
        }

        public ExpressionSymbol(IErrorReport errorReport, string symbol, string title,
            bool isPlaceholder, bool isVisibleToEditor, IFunction func, string prefix, string postfix)
            : base(symbol, title, isPlaceholder, prefix, postfix)
        {
            this.func = func ?? throw new ArgumentNullException($"{nameof(func)} cannot be null.");
            this.errorReport = errorReport ?? throw new ArgumentNullException($"{nameof(errorReport)} cannot be null.");
            IsVisibleToEditor = isVisibleToEditor;
        }

        public override string Value => func.Execute(errorReport);
    }
}
