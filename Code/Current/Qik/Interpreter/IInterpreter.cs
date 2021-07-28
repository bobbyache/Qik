using CygSoft.Qik.Functions;

namespace CygSoft.Qik
{
    public interface IInterpreter
    {
        ISymbolTerminal Interpret(IFunctionFactory functionFactory, string scriptText);
    }
}
