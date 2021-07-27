
namespace CygSoft.Qik.Functions
{
    public class IntegerFunction : BaseFunction
    {
        private readonly string text;

        public IntegerFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, string text)
            : base(funcInfo, symbolTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return this.text;
        }
    }
}
