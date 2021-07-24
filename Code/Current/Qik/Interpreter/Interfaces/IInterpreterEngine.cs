using System;

namespace CygSoft.Qik
{
    public interface IInterpreterEngine
    {
        event EventHandler BeforeInterpret;
        event EventHandler AfterInterpret;
        event EventHandler<InterpretErrorEventArgs> InterpretError;

        string[] Placeholders { get; }
        string[] Symbols { get; }
        IExpression[] Expressions { get; }

        bool HasErrors { get; }

        void Interpret(string scriptText);

        ISymbolInfo GetSymbolInfo(string symbol);
        ISymbolInfo GetPlaceholderInfo(string placeholder);
        ISymbolInfo[] GetSymbolInfoSet(string[] symbols);
        string GetValueOfSymbol(string symbol);
        string GetValueOfPlaceholder(string placeholder);
    }
}
