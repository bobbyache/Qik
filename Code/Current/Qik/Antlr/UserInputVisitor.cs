using Antlr4.Runtime.Misc;

namespace CygSoft.Qik.Antlr
{
    internal class UserInputVisitor : QikTemplateBaseVisitor<string>
    {
        private readonly IGlobalTable scopeTable;
        private readonly IErrorReport errorReport;

        internal UserInputVisitor(IGlobalTable scopeTable, IErrorReport errorReport)
        {
            this.scopeTable = scopeTable;
            this.errorReport = errorReport;
        }

        public override string VisitInputDecl([NotNull] QikTemplateParser.InputDeclContext context)
        {
            // int line = context.Start.Line;
            // int column = context.Start.Column;

            var inputSymbol = new InputSymbol(context.VARIABLE().GetText());
            inputSymbol.SetValue(Common.StripOuterQuotes(context.STRING().GetText()));

            scopeTable.AddSymbol(inputSymbol);
            
            return base.VisitInputDecl(context);
        }
    }
}
