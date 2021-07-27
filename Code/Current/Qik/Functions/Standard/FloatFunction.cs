
namespace CygSoft.Qik.Functions
{
    public class FloatFunction : BaseFunction
    {
        private readonly string text;

        public FloatFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, string text)
            : base(funcInfo, symbolTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return text;
        }
    }
}
