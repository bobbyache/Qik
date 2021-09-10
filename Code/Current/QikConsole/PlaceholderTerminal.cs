using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.QikConsole
{
    public class PlaceholderTerminal
    {
        private readonly string Id;
        private readonly ISymbolTerminal symbolTerminal;

        public string[] Placeholders { get => symbolDictionary.Keys.ToArray(); }

        public Dictionary<string, string> symbolDictionary =  new Dictionary<string, string>();

        public PlaceholderTerminal(string id, ISymbolTerminal symbolTerminal, string placeholderPrefix, string placeholderPostfix)
        {
            this.Id = id;
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
