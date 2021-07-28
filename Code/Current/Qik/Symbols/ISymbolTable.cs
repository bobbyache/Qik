
namespace CygSoft.Qik
{
    public interface ISymbolTable : ISymbolTerminal
    {
        void Clear();

        void AddSymbol(ISymbol symbol);      
    }

    public interface ISymbolTerminal
    {
        string[] Symbols { get; }
        string[] InputSymbols { get; }

        void SetValue(string inputSymbol, string value);

        string GetValue(string symbol);   
    }

}