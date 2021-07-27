
namespace CygSoft.Qik
{
    public interface IGlobalTable
    {
        string[] Symbols { get; }

        void Clear();

        void AddSymbol(ISymbol symbol);
        string GetValueOfSymbol(string symbol);        
    }
}