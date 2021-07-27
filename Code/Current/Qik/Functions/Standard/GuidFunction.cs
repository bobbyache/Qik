using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class GuidFunction : BaseFunction
    {
        public GuidFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, List<IFunction> functionArguments) : base(funcInfo, symbolTable, functionArguments) {}

        public override string Execute(IErrorReport errorReport)
        {
            if (functionArguments.Count() > 1)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Guid function requires a single empty string parameter.", this.Name));

            string result = null;
            try
            {
                if (functionArguments.Count() == 1) 
                {
                    string txt = functionArguments[0].Execute(errorReport);
                    result = txt == "u" ? Guid.NewGuid().ToString().ToUpper() : Guid.NewGuid().ToString();
                }
                else
                {
                    result = Guid.NewGuid().ToString();
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
