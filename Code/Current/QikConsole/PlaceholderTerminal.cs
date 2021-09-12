using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.QikConsole
{
    public class PlaceholderTerminal
    {
        private readonly ISymbolTerminal symbolTerminal;

        public string[] Placeholders { get => symbolDictionary.Keys.ToArray(); }

        public Dictionary<string, string> symbolDictionary =  new Dictionary<string, string>();

        public PlaceholderTerminal(ISymbolTerminal symbolTerminal, string placeholderPrefix, string placeholderPostfix)
        {
            this.symbolTerminal = symbolTerminal;
            
            foreach (var symbol in symbolTerminal.Symbols)
            {
                symbolDictionary.Add(placeholderPrefix + symbol.Replace("@", "") + placeholderPostfix, symbol);
            }
        }

        public string GetValue(string placeHolderSymbol)
        {
            var symbol = symbolDictionary[placeHolderSymbol];
            return symbolTerminal.GetValue(symbol);
        }
    }
}
