﻿namespace CygSoft.Qik
{
    public interface ISymbol
    {
        string Symbol { get; }
        string Title { get; }
        string Description { get; }
        string Value { get; }
        string Placeholder { get; }
        bool IsPlaceholder { get; }
    }
}
