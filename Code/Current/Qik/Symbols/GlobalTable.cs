using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik
{
    public class GlobalTable : IGlobalTable
    {
        private class SymbolInfo : ISymbolInfo
        {
            public string Symbol { get; }
            public string Placeholder { get; }
            public string Title { get; }

            public SymbolInfo(string placeholder, string symbol, string title)
            {
                Symbol = symbol;
                Placeholder = placeholder;
                Title = title;
            }
        }

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

        public string[] Placeholders
        {
            get
            {
                if (table.Values.Where(r => r.IsPlaceholder == true).Any())
                    return table.Values.Where(r => r.IsPlaceholder == true).Select(r => r.Placeholder).ToArray();
                else
                    return new string[0];
            }
        }

        public IInputField[] InputFields => table.Values.OfType<IInputField>().ToArray();
        public IExpression[] Expressions => table.Values.OfType<IExpression>().ToArray();

        public void Clear()
        {
            table.Clear();
        }

        public void AddSymbol(ISymbol symbol)
        {
            if (!table.ContainsKey(symbol.Symbol))
                table.Add(symbol.Symbol, symbol);
        }

        public void Input(string inputSymbol, string value)
        {
            if (table.ContainsKey(inputSymbol))
            {
                ISymbol symbol = table[inputSymbol];

                if (symbol is AutoInputSymbol)
                {
                    AutoInputSymbol autoInputSymbol = table[inputSymbol] as AutoInputSymbol;
                    autoInputSymbol.SetValue(value);
                }
                else if (symbol is TextInputSymbol)
                {
                    TextInputSymbol textInputSymbol = table[inputSymbol] as TextInputSymbol;
                    textInputSymbol.SetValue(value);
                }
            }
        }

        public ISymbolInfo GetPlaceholderInfo(string placeholder)
        {
            List<BaseSymbol> symbols = table.Values.Cast<BaseSymbol>().ToList();

            if (symbols.Any(s => s.Placeholder == placeholder))
            {
                BaseSymbol baseSymbol = symbols.Where(s => s.Placeholder == placeholder).SingleOrDefault() as BaseSymbol;
                ISymbolInfo placeholderInfo =
                    new SymbolInfo(baseSymbol.Placeholder, baseSymbol.Symbol, baseSymbol.Title);
                return placeholderInfo;
            }

            return null;
        }

        public ISymbolInfo GetSymbolInfo(string symbol)
        {
            if (table.ContainsKey(symbol))
            {
                ISymbol baseSymbol = table[symbol];
                ISymbolInfo symbolInfo =
                    new SymbolInfo(baseSymbol.Placeholder, baseSymbol.Symbol, baseSymbol.Title);
                return symbolInfo;
            }
            return null;
        }

        public ISymbolInfo[] GetSymbolInfoSet(string[] symbols)
        {
            List<ISymbolInfo> symbolInfoSet = new List<ISymbolInfo>();
            foreach (string symbol in symbols)
            {
                ISymbolInfo symbolInfo = GetSymbolInfo(symbol);
                if (symbolInfo != null)
                    symbolInfoSet.Add(symbolInfo);
            }
            return symbolInfoSet.ToArray();
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

        public string GetValueOfPlacholder(string placeholder)
        {
            List<BaseSymbol> symbols = table.Values.Cast<BaseSymbol>().ToList();

            if (symbols.Any(s => s.Placeholder == placeholder))
            {
                BaseSymbol baseSymbol = symbols.Where(s => s.Placeholder == placeholder).SingleOrDefault() as BaseSymbol;
                return baseSymbol.Value;
            }

            return null;
        }

        public string GetTitleOfPlacholder(string placeholder)
        {
            List<BaseSymbol> symbols = table.Values.Cast<BaseSymbol>().ToList();

            if (symbols.Any(s => s.Placeholder == placeholder))
            {
                BaseSymbol baseSymbol = symbols.Where(s => s.Placeholder == placeholder).SingleOrDefault() as BaseSymbol;
                return baseSymbol.Title;
            }

            return null;
        }
    }
}
