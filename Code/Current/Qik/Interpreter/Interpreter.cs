using System;
using CygSoft.Qik.Antlr;

namespace CygSoft.Qik
{
    public class Interpreter : IInterpreter
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

        // Default functionality
        public Interpreter()
        {
            syntaxValidator = new SyntaxValidator();
            interpreterEngine = new InterpreterEngine(new GlobalTable(), new ErrorReport());
        }

        // For testing purposes:
        public Interpreter(ISyntaxValidator syntaxValidator, IInterpreterEngine interpreterEngine)
        {
            this.syntaxValidator = syntaxValidator ?? throw new ArgumentNullException($"{nameof(syntaxValidator)} cannot be null.");
            this.interpreterEngine = interpreterEngine ?? throw new ArgumentNullException($"{nameof(interpreterEngine)} cannot be null.");
        }

        public void Interpret(string scriptText)
        {
            CheckSyntax(scriptText);

            if (!syntaxValidator.HasErrors)
                InterpretInstructions(scriptText);
            
        }

        public string GetValueOfSymbol(string symbol) => interpreterEngine.GetValueOfSymbol(symbol);

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

        private void Interpreter_CompileError(object sender, InterpretErrorEventArgs e) => CompileError?.Invoke(this, e);
    }
}
