
namespace CygSoft.Qik
{
    public abstract class InputSymbol : BaseSymbol, IInputField
    {
        public string DefaultValue { get; }

        public InputSymbol(string symbol, string title, string defaultValue, 
            bool isPlaceholder)
            : base(symbol, title, isPlaceholder)
        {
            DefaultValue = Common.StripOuterQuotes(defaultValue);
        }

        public InputSymbol(string symbol, string title, string defaultValue, bool isPlaceholder,  
            string prefix, string postfix)
            : base(symbol, title, isPlaceholder, prefix, postfix)
        {
            DefaultValue = defaultValue;
        }
    }
}
