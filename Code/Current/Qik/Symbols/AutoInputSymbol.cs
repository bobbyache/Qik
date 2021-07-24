
namespace CygSoft.Qik
{
    public class AutoInputSymbol : InputSymbol
    {
        private string value = null;

        public AutoInputSymbol(string symbol, string title) : base(symbol, title, null)
        {
            value = null;
        }

        public AutoInputSymbol(string symbol, string title, string prefix, string postfix)
            : base(symbol, title, null, prefix, postfix)
        {
            value = null;
        }

        public override string Value => value;

        public void SetValue(string value) => this.value = value;
    }
}
