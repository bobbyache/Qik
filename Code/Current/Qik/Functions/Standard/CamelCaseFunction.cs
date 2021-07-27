using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class CamelCaseFunction : BaseFunction
    {
        public CamelCaseFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, List<IFunction> functionArguments) : base(funcInfo, symbolTable, functionArguments)
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
                    string firstChar = txt.Substring(0, 1);
                    string theRest = txt.Substring(1, txt.Length - 1);
                    result = firstChar.ToLower() + theRest;
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
