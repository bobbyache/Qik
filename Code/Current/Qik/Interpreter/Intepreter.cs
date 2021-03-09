﻿using System;
using CygSoft.Qik.Antlr;

namespace CygSoft.Qik
{
    public class Intepreter : IInterpreter
    {
        public event EventHandler BeforeInput;
        public event EventHandler AfterInput;
        public event EventHandler BeforeCompile;
        public event EventHandler AfterCompile;
        public event EventHandler<InterpretErrorEventArgs> CompileError;

        private readonly ISyntaxValidator syntaxValidator = null;
        private readonly IInterpreterEngine interpreterEngine = null;

        public bool HasErrors => syntaxValidator.HasErrors || interpreterEngine.HasErrors;
        public string[] Symbols => interpreterEngine.Symbols;
        public string[] Placeholders => interpreterEngine.Placeholders;
        public IInputField[] InputFields => interpreterEngine.InputFields;
        public IExpression[] Expressions => interpreterEngine.Expressions;

        // TODO: Only allow inject (see below constructor). Fix refs in tests to make it clear what is being used
        // + can mock out and deeply test.
        // QUESTION: How does one inject a service that requires constructor arguments.
        // Should we even do this? This is probably enough to make it testable. Inject to test, just use as top level service.
        public Intepreter()
        {
            syntaxValidator = new SyntaxValidator();
            interpreterEngine = new InterpreterEngine();
        }

        // For testing purposes:
        public Intepreter(ISyntaxValidator syntaxValidator, IInterpreterEngine interpreterEngine)
        {
            this.syntaxValidator = syntaxValidator;
            this.interpreterEngine = interpreterEngine;
        }

        public void Interpret(string scriptText)
        {
            CheckSyntax(scriptText);

            if (!syntaxValidator.HasErrors)
                InterpretInstructions(scriptText);
            
        }

        public void Input(string symbol, string value)
        {
            interpreterEngine.BeforeInput += interpreterEngine_BeforeInput;
            interpreterEngine.AfterInput += interpreterEngine_AfterInput;

            interpreterEngine.Input(symbol, value);

            interpreterEngine.BeforeInput -= interpreterEngine_BeforeInput;
            interpreterEngine.AfterInput -= interpreterEngine_AfterInput;
        }

        public ISymbolInfo GetPlaceholderInfo(string placeholder) => interpreterEngine.GetPlaceholderInfo(placeholder);

        public ISymbolInfo GetSymbolInfo(string symbol) => interpreterEngine.GetSymbolInfo(symbol);

        public ISymbolInfo[] GetSymbolInfoSet(string[] symbols) => interpreterEngine.GetSymbolInfoSet(symbols);

        public string GetValueOfSymbol(string symbol) => interpreterEngine.GetValueOfSymbol(symbol);

        public string GetValueOfPlaceholder(string placeholder) => interpreterEngine.GetValueOfPlaceholder(placeholder);

        public string GetTitleOfPlaceholder(string placeholder) => interpreterEngine.GetTitleOfPlaceholder(placeholder);

        // TODO: Looks like placeholder is configurable. What happens if we change it?
        // Tests need to be configurable!
        public string TextToSymbol(string text) => "@" + text;

        public string TextToPlaceholder(string text) => "@{" + text + "}";

        private void InterpretInstructions(string scriptText)
        {
            interpreterEngine.BeforeInterpret += Interpreter_BeforeCompile;
            interpreterEngine.AfterInterpret += Intepreter_AfterCompile;
            interpreterEngine.InterpretError += Interpreter_CompileError;

            interpreterEngine.Interpret(scriptText);

            interpreterEngine.InterpretError -= Interpreter_CompileError;
            interpreterEngine.BeforeInterpret -= Interpreter_BeforeCompile;
            interpreterEngine.AfterInterpret -= Intepreter_AfterCompile;
        }

        private void CheckSyntax(string scriptText)
        {
            syntaxValidator.CompileError += Interpreter_CompileError;
            syntaxValidator.Validate(scriptText);
            syntaxValidator.CompileError -= Interpreter_CompileError;
        }

        // TODO: Should this not inherit from the base class? Investigate why not?
        // If necessary, look for other places where this occurs.
        private void Intepreter_AfterCompile(object sender, EventArgs e) => AfterCompile?.Invoke(this, e);

        private void Interpreter_BeforeCompile(object sender, EventArgs e) => BeforeCompile?.Invoke(this, e);

        private void interpreterEngine_AfterInput(object sender, EventArgs e) => AfterInput?.Invoke(this, e);

        private void interpreterEngine_BeforeInput(object sender, EventArgs e) => BeforeInput?.Invoke(this, e);

        private void Interpreter_CompileError(object sender, InterpretErrorEventArgs e) => CompileError?.Invoke(this, e);
    }
}