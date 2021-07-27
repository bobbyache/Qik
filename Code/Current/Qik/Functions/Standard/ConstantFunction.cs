
namespace CygSoft.Qik.Functions
{
    public class ConstantFunction : BaseFunction
    {
        private readonly string text;

        public ConstantFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, string text)
            : base(funcInfo, symbolTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport) => text;
    }
}
