namespace CygSoft.Qik
{
    public abstract class BaseSymbol : ISymbol 
    {
        // TODO: This should not be here. Can't hard code this.
        // Should rather pass it in as a constructor parameter
        // Therefore remove constructor without these parameters.
        private readonly string prefix = "@{";
        private readonly string postfix = "}";

        public string Title { get; }
        public bool IsPlaceholder { get; }
        public string Symbol { get; }

        public abstract string Value { get; }

        public string Placeholder
        {
            get
            {
                if (Symbol != null)
                    return prefix + Symbol.Substring(1, Symbol.Length - 1) + postfix;
                else
                    return null;
            }
        }

        public BaseSymbol(string symbol, string title, bool isPlaceholder)
        {
            Symbol = symbol;
            Title = title;
            IsPlaceholder = isPlaceholder;
        }

        public BaseSymbol(string symbol, string title, bool isPlaceholder, string prefix, string postfix)
        {
            this.prefix = prefix;
            this.postfix = postfix;

            Symbol = symbol;
            Title = title;
            IsPlaceholder = isPlaceholder;
        }
    }
}
