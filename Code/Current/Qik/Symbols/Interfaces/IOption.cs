﻿namespace CygSoft.Qik
{
    public interface IOption
    {
        string Value { get; set; }
        int Index { get; }
        string Title { get; }
        string Description { get; }
    }
}
