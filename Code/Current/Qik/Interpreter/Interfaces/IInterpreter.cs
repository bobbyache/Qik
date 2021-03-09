﻿using System;

namespace CygSoft.Qik
{
    public interface IInterpreter
    {
        event EventHandler<InterpretErrorEventArgs> CompileError;

        event EventHandler BeforeCompile;
        event EventHandler AfterCompile;

        event EventHandler BeforeInput;
        event EventHandler AfterInput;

        bool HasErrors { get; }
        string[] Placeholders { get; }
        string[] Symbols { get; }
        IExpression[] Expressions { get; }
        IInputField[] InputFields { get; }

        void Interpret(string scriptText);

        void Input(string symbol, string value);

        string TextToPlaceholder(string text);
        string TextToSymbol(string text);

        ISymbolInfo GetPlaceholderInfo(string placeholder);
        ISymbolInfo GetSymbolInfo(string symbol);
        ISymbolInfo[] GetSymbolInfoSet(string[] symbols);

        string GetTitleOfPlaceholder(string placeholder);
        string GetValueOfPlaceholder(string placeholder);
        string GetValueOfSymbol(string symbol);
    }
}