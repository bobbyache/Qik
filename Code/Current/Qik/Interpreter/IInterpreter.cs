using System;

namespace CygSoft.Qik
{
    public interface IInterpreter
    {
        ISymbolTerminal Interpret(string scriptText);
    }
}
