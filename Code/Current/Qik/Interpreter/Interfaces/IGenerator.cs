﻿namespace CygSoft.Qik
{
    public interface IGenerator
    {
        string Generate(ICompiler compiler, string templateText);
        string Generate(IBatchCompiler compiler, string templateText);
    }
}
