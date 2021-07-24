

namespace CygSoft.Qik
{
    public class TextInputSymbol : InputSymbol, ITextField
    {
        private string value = null;

        public override string Value => value;

        public TextInputSymbol(string symbol, string title, string defaultValue)
            : base(symbol, title, defaultValue)
        {
            value = defaultValue;
        }

        public TextInputSymbol(string symbol, string title, string defaultValue,
            string prefix, string postfix)
            : base(symbol, title, defaultValue, prefix, postfix)
        {
            value = defaultValue;
        }

        public void SetValue(string value) => this.value = value;
    }
}
