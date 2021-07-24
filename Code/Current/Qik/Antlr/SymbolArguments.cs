

namespace CygSoft.Qik.Antlr
{
    internal class SymbolArguments
    {
        public string Title { get; private set; }
        public string Default { get; private set; }

        private readonly IErrorReport errorReport;

        public SymbolArguments(IErrorReport errorReport)
        {
            this.errorReport = errorReport;
        }

        public void Process(QikTemplateParser.DeclArgsContext context)
        {
            foreach (var declArg in context.declArg())
            {
                if (declArg.IDENTIFIER() != null)
                {
                    var identifier = declArg.IDENTIFIER().GetText();
                    var value = Common.StripOuterQuotes(declArg.STRING().GetText());

                    switch (identifier)
                    {
                        case "Title":
                            this.Title = value;
                            break;
                        case "Default":
                            this.Default = value;
                            break;
                        default:
                            errorReport.AddError(new CustomError(context.Start.Line, context.Start.Column, "Unsupported Declaration Argument", context.Parent.GetText()));
                            break;
                    }
                }
            }
        }
    }
}
