
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
    }
}
