using System;

namespace CygSoft.Qik
{
    public interface IInterpreter
    {
        event EventHandler<InterpretErrorEventArgs> CompileError;

        event EventHandler BeforeCompile;
        event EventHandler AfterCompile;

        bool HasErrors { get; }
        string[] Placeholders { get; }
        string[] Symbols { get; }
        IExpression[] Expressions { get; }
        void Interpret(string scriptText);

        ISymbolInfo GetPlaceholderInfo(string placeholder);
        ISymbolInfo GetSymbolInfo(string symbol);
        ISymbolInfo[] GetSymbolInfoSet(string[] symbols);
        string GetValueOfPlaceholder(string placeholder);
        string GetValueOfSymbol(string symbol);
    }
}
