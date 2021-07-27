using System;

namespace CygSoft.Qik.Functions
{
    public class NewlineFunction : BaseFunction
    {
        public NewlineFunction(IFuncInfo funcInfo, ISymbolTable symbolTable)
            : base(funcInfo, symbolTable)
        {
        }

        public override string Execute(IErrorReport errorReport)
        {
            return Environment.NewLine;
        }
    }
}
