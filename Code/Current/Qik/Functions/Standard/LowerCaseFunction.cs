using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class LowerCaseFunction : BaseFunction
    {

        public LowerCaseFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, List<IFunction> functionArguments)
            : base(funcInfo, symbolTable, functionArguments)
        {

        }

        public override string Execute(IErrorReport errorReport)
        {
            if (functionArguments.Count() != 1)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Unexpected number of arguments", this.Name));

            string result = null;
            try
            {
                string txt = functionArguments[0].Execute(errorReport);

                if (txt != null && txt.Length >= 1)
                {
                    result = txt.ToLower();
                }
            }
            catch (Exception)
            {
                errorReport.AddError(new CustomError(this.Line, this.Column, "Bad function call.", this.Name));
            }
            return result;
        }
    }
}
