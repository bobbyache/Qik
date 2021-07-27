using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CygSoft.Qik
{
    public class GlobalTable : IGlobalTable
    {
        private readonly Dictionary<string, ISymbol> table = new Dictionary<string, ISymbol>();

        public string[] Symbols
        {
            get
            {
                if (table.Keys.Select(r => r).Any())
                    return table.Keys.Select(r => r).ToArray();
                else
                    return new string[0];
            }
        }

        public void Clear()
        {
            table.Clear();
        }

        public void AddSymbol(ISymbol symbol)
        {
            if (!table.ContainsKey(symbol.Symbol))
                table.Add(symbol.Symbol, symbol);
        }

        public string GetValueOfSymbol(string symbol)
        {
            if (table.ContainsKey(symbol))
            {
                ISymbol baseSymbol = table[symbol];
                return baseSymbol.Value;
            }
            return null;
        }
    }
}
