using System;

namespace CygSoft.Qik
{
    public interface IInterpreterEngine
    {
        event EventHandler BeforeInput;
        event EventHandler AfterInput;
        event EventHandler BeforeInterpret;
        event EventHandler AfterInterpret;
        event EventHandler<InterpretErrorEventArgs> InterpretError;

        string[] Placeholders { get; }
        string[] Symbols { get; }
        IInputField[] InputFields { get; }
        IExpression[] Expressions { get; }

        bool HasErrors { get; }

        void CreateFieldInput(string symbol, string fieldName);

        void Interpret(string scriptText);
        void Input(string symbol, string value);

        ISymbolInfo GetSymbolInfo(string symbol);
        ISymbolInfo GetPlaceholderInfo(string placeholder);
        ISymbolInfo[] GetSymbolInfoSet(string[] symbols);
        string GetValueOfSymbol(string symbol);
        string GetValueOfPlaceholder(string placeholder);
        string GetTitleOfPlaceholder(string placeholder);
    }
}
