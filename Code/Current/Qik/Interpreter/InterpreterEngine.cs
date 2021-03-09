﻿using Antlr4.Runtime;
using System;
using System.Linq;
using CygSoft.Qik.Antlr;

namespace CygSoft.Qik
{
    public class InterpreterEngine : IInterpreterEngine
    {
        public event EventHandler BeforeInput;
        public event EventHandler AfterInput;
        public event EventHandler BeforeInterpret;
        public event EventHandler AfterInterpret;
        public event EventHandler<InterpretErrorEventArgs> InterpretError;

        private readonly IGlobalTable scopeTable;
        private readonly IErrorReport errorReport;

        public bool HasErrors { get; private set; } = false;

        public string[] Symbols => scopeTable.Symbols;

        public IInputField[] InputFields => scopeTable.InputFields;
        public IExpression[] Expressions => scopeTable.Expressions;

        public string[] Placeholders => scopeTable.Placeholders;

        public InterpreterEngine(IGlobalTable scopeTable, IErrorReport errorReport )
        {
            this.scopeTable = scopeTable;
            this.errorReport = errorReport;
        }

        public void CreateFieldInput(string symbol, string fieldName, string description)
        {
            var autoInputSymbol = new AutoInputSymbol(symbol, fieldName, description);

            if (!scopeTable.Symbols.Contains(autoInputSymbol.Symbol))
                scopeTable.AddSymbol(autoInputSymbol);
        }

        public void Input(string symbol, string value)
        {
            HasErrors = false;

            BeforeInput?.Invoke(this, new EventArgs());

            scopeTable.Input(symbol, value);

            AfterInput?.Invoke(this, new EventArgs());
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

                // TODO: This doesn't appear to be used...
                bool success = !this.errorReport.HasErrors;
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
            // TODO: Can't this stuff all be injected and mocked out for testing?
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
            // TODO: Can't this stuff all be injected and mocked out for testing?
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

        public ISymbolInfo GetSymbolInfo(string symbol) => scopeTable.GetSymbolInfo(symbol);

        public ISymbolInfo GetPlaceholderInfo(string placeholder) => scopeTable.GetPlaceholderInfo(placeholder);

        public ISymbolInfo[] GetSymbolInfoSet(string[] symbols) => scopeTable.GetSymbolInfoSet(symbols);

        public string GetValueOfSymbol(string symbol) => scopeTable.GetValueOfSymbol(symbol);

        public string GetValueOfPlaceholder(string placeholder) => scopeTable.GetValueOfPlacholder(placeholder);

        public string GetTitleOfPlaceholder(string placeholder) => scopeTable.GetTitleOfPlacholder(placeholder);
    }
}
