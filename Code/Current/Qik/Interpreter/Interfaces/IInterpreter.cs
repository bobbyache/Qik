using System;

namespace CygSoft.Qik
{
    public interface IInterpreter
    {
        event EventHandler<InterpretErrorEventArgs> CompileError;

        bool HasErrors { get; }
        ISymbolTerminal Interpret(string scriptText);
    }
}
