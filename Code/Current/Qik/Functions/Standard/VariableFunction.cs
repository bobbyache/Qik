
namespace CygSoft.Qik.Functions
{
    public class VariableFunction : BaseFunction
    {
        private readonly string symbol;

        public VariableFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, string symbol)
            : base(funcInfo, symbolTable)
        {
            this.symbol = symbol;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return base.symbolTable.GetValue(this.symbol);
        }
    }
}
