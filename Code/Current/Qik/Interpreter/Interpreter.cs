using System;
using CygSoft.Qik.Antlr;

namespace CygSoft.Qik
{
    public class Interpreter : IInterpreter
    {
        public event EventHandler<InterpretErrorEventArgs> CompileError;

        private readonly ISyntaxValidator syntaxValidator = null;
        private readonly IInterpreterEngine interpreterEngine = null;

        public bool HasErrors => syntaxValidator.HasErrors || interpreterEngine.HasErrors;

        // Default functionality
        public Interpreter()
        {
            //
            // TODO (Rob) Would it not be better to seperate error detection completely from symbol generation?
            // Parse for errors... only if not found, go and create the symbol table.
            syntaxValidator = new SyntaxValidator();
            interpreterEngine = new InterpreterEngine(new SymbolTable());
        }

        // For testing purposes:
        public Interpreter(ISyntaxValidator syntaxValidator, IInterpreterEngine interpreterEngine)
        {
            this.syntaxValidator = syntaxValidator ?? throw new ArgumentNullException($"{nameof(syntaxValidator)} cannot be null.");
            this.interpreterEngine = interpreterEngine ?? throw new ArgumentNullException($"{nameof(interpreterEngine)} cannot be null.");
        }

        public ISymbolTerminal Interpret(string scriptText)
        {
            CheckSyntax(scriptText);

            if (!syntaxValidator.HasErrors)
                return InterpretInstructions(scriptText);

            return null;
        }

        private ISymbolTerminal InterpretInstructions(string scriptText)
        {
            interpreterEngine.InterpretError += Interpreter_CompileError;

            ISymbolTerminal terminal = interpreterEngine.Interpret(scriptText);

            interpreterEngine.InterpretError -= Interpreter_CompileError;

            return terminal;
        }

        private void CheckSyntax(string scriptText)
        {
            syntaxValidator.CompileError += Interpreter_CompileError;
            syntaxValidator.Validate(scriptText);
            syntaxValidator.CompileError -= Interpreter_CompileError;
        }

        private void Interpreter_CompileError(object sender, InterpretErrorEventArgs e) => CompileError?.Invoke(this, e);
    }
}
