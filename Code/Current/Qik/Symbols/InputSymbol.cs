
namespace CygSoft.Qik
{
    public class InputSymbol : BaseSymbol
    {

        private string value = null;

        public override string Value => value;

        public InputSymbol(string symbol)
            : base(symbol)
        {
        }

        public InputSymbol(string symbol, string prefix, string postfix)
            : base(symbol, prefix, postfix)
        {
        }

        public void SetValue(string value) => this.value = value;
    }
}
