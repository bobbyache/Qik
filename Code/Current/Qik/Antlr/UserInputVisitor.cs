using Antlr4.Runtime.Misc;

namespace CygSoft.Qik.Antlr
{
    internal class UserInputVisitor : QikTemplateBaseVisitor<string>
    {
        private readonly ISymbolTable symbolTable;
        private readonly IErrorReport errorReport;

        internal UserInputVisitor(ISymbolTable symbolTable, IErrorReport errorReport)
        {
            this.symbolTable = symbolTable;
            this.errorReport = errorReport;
        }

        public override string VisitInputDecl([NotNull] QikTemplateParser.InputDeclContext context)
        {
            // int line = context.Start.Line;
            // int column = context.Start.Column;

            var inputSymbol = new InputSymbol(context.VARIABLE().GetText());
            inputSymbol.SetValue(Common.StripOuterQuotes(context.STRING().GetText()));

            symbolTable.AddSymbol(inputSymbol);
            
            return base.VisitInputDecl(context);
        }
    }
}
