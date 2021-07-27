using System;

namespace CygSoft.Qik
{
    public interface IInterpreterEngine
    {
        event EventHandler BeforeInterpret;
        event EventHandler AfterInterpret;
        event EventHandler<InterpretErrorEventArgs> InterpretError;
        string[] Symbols { get; }
        bool HasErrors { get; }
        void Interpret(string scriptText);
        string GetValueOfSymbol(string symbol);
    }
}
