using System;

namespace CygSoft.Qik
{
    public interface IInterpreter
    {
        event EventHandler<InterpretErrorEventArgs> CompileError;

        event EventHandler BeforeCompile;
        event EventHandler AfterCompile;

        bool HasErrors { get; }
        string[] Symbols { get; }
        void Interpret(string scriptText);
        string GetValueOfSymbol(string symbol);
    }
}
