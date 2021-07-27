using Antlr4.Runtime;
using System;
using System.Linq;
using CygSoft.Qik.Antlr;

namespace CygSoft.Qik
{
    public class InterpreterEngine : IInterpreterEngine
    {
        public event EventHandler BeforeInterpret;
        public event EventHandler AfterInterpret;
        public event EventHandler<InterpretErrorEventArgs> InterpretError;

        private readonly IGlobalTable scopeTable;
        private readonly IErrorReport errorReport;

        public bool HasErrors { get; private set; } = false;

        public string[] Symbols => scopeTable.Symbols;

        public InterpreterEngine(IGlobalTable scopeTable, IErrorReport errorReport )
        {
            this.scopeTable = scopeTable ?? throw new ArgumentNullException($"{nameof(scopeTable)} cannot be null.");
            this.errorReport = errorReport ?? throw new ArgumentNullException($"{nameof(errorReport)} cannot be null.");
        }

        public void Interpret(string scriptText)
        {
            HasErrors = false;
            BeforeInterpret?.Invoke(this, new EventArgs());

            try
            {
                scopeTable.Clear();

                errorReport.Reporting = true;
                errorReport.ExecutionErrorDetected += ErrorReport_ExecutionErrorDetected;

                InterpretInputs(scriptText);
                InterpretExpressions(scriptText);

                errorReport.ExecutionErrorDetected -= ErrorReport_ExecutionErrorDetected;
                errorReport.Reporting = false;

                this.errorReport.Clear();
            }
            catch (Exception exception)
            {
                HasErrors = true;
                InterpretError?.Invoke(this, new InterpretErrorEventArgs(exception));
            }
            finally
            {
                AfterInterpret?.Invoke(this, new EventArgs());
            }
        }

        private void InterpretExpressions(string scriptText)
        {
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var tree = parser.template();

            var expressionVisitor = new ExpressionVisitor(this.scopeTable, this.errorReport);
            expressionVisitor.Visit(tree);
        }

        private void InterpretInputs(string scriptText)
        {
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var tree = parser.template();

            var controlVisitor = new UserInputVisitor(this.scopeTable, this.errorReport);
            controlVisitor.Visit(tree);
        }

        private void ErrorReport_ExecutionErrorDetected(object sender, InterpretErrorEventArgs e)
        {
            HasErrors = true;
            InterpretError?.Invoke(this, e);
        }

        public string GetValueOfSymbol(string symbol) => scopeTable.GetValueOfSymbol(symbol);
    }
}
