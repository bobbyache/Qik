
namespace CygSoft.Qik
{
    public abstract class InputSymbol : BaseSymbol, IInputField
    {
        public string DefaultValue { get; }

        public InputSymbol(string symbol, string title, string defaultValue)
            : base(symbol, title)
        {
            DefaultValue = Common.StripOuterQuotes(defaultValue);
        }

        public InputSymbol(string symbol, string title, string defaultValue,  
            string prefix, string postfix)
            : base(symbol, title, prefix, postfix)
        {
            DefaultValue = defaultValue;
        }
    }
}
