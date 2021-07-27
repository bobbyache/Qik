using System;

namespace CygSoft.Qik
{
    public interface IInterpreterEngine
    {
        event EventHandler<InterpretErrorEventArgs> InterpretError;
        bool HasErrors { get; }
        ISymbolTerminal Interpret(string scriptText);
    }
}
