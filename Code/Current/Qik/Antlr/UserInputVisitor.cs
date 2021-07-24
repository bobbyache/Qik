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

        public override string VisitTextBox(QikTemplateParser.TextBoxContext context)
        {
            var controlId = context.VARIABLE().GetText();

            var symbolArguments = new SymbolArguments(errorReport);
            symbolArguments.Process(context.declArgs());

            var textInputSymbol = new TextInputSymbol(controlId, symbolArguments.Title, symbolArguments.Default);
            scopeTable.AddSymbol(textInputSymbol);

            return base.VisitTextBox(context);
        }

        public override string VisitInput([NotNull] QikTemplateParser.InputContext context)
        {
            // int line = context.Start.Line;
            // int column = context.Start.Column;

            var textInputSymbol = new TextInputSymbol(context.VARIABLE().GetText(), "", Common.StripOuterQuotes(context.STRING().GetText()));
            scopeTable.AddSymbol(textInputSymbol);
            
            return base.VisitInput(context);
        }
    }
}
