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

        private readonly ISymbolTable symbolTable;

        public bool HasErrors { get; private set; } = false;

        public string[] Symbols => symbolTable.Symbols;

        public InterpreterEngine(ISymbolTable symbolTable)
        {
            this.symbolTable = symbolTable ?? throw new ArgumentNullException($"{nameof(symbolTable)} cannot be null.");
        }

        public ISymbolTerminal Interpret(string scriptText)
        {
            HasErrors = false;

            try
            {
                symbolTable.Clear();

                InterpretInputs(scriptText);
                InterpretExpressions(scriptText);
            }
            catch (Exception exception)
            {
                HasErrors = true;
                InterpretError?.Invoke(this, new InterpretErrorEventArgs(exception));
            }

            return this.symbolTable;
        }

        private void InterpretExpressions(string scriptText)
        {
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var tree = parser.template();

            var expressionVisitor = new ExpressionVisitor(this.symbolTable);
            expressionVisitor.Visit(tree);
        }

        private void InterpretInputs(string scriptText)
        {
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var tree = parser.template();

            var controlVisitor = new UserInputVisitor(this.symbolTable);
            controlVisitor.Visit(tree);
        }

        public string GetValueOfSymbol(string symbol) => symbolTable.GetValue(symbol);
    }
}
