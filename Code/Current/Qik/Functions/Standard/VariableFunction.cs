﻿
namespace CygSoft.Qik.Functions
{
    public class VariableFunction : BaseFunction
    {
        private readonly string symbol;

        public VariableFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, string symbol)
            : base(funcInfo, scopeTable)
        {
            this.symbol = symbol;
        }

        public override string Execute(IErrorReport errorReport)
        {
            return base.scopeTable.GetValueOfSymbol(this.symbol);
        }
    }
}
