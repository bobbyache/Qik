
namespace CygSoft.Qik
{
    public interface IGlobalTable
    {
        IExpression[] Expressions { get; }
        string[] Placeholders { get; }
        string[] Symbols { get; }

        void Clear();

        void AddSymbol(ISymbol symbol);

        ISymbolInfo GetPlaceholderInfo(string placeholder);
        ISymbolInfo GetSymbolInfo(string symbol);
        ISymbolInfo[] GetSymbolInfoSet(string[] symbols);
        string GetValueOfPlacholder(string placeholder);
        string GetValueOfSymbol(string symbol);
    }
}