using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class IndentFunction : BaseFunction
    {
        public IndentFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, List<IFunction> functionArguments)
            : base(funcInfo, symbolTable, functionArguments)
        {
        }

        public override string Execute(IErrorReport errorReport)
        {
            if (functionArguments.Count() != 3)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Unexpected number of arguments", this.Name));

            string result = null;
            try
            {
                string txt = functionArguments[0].Execute(errorReport);
                string indentType = functionArguments[1].Execute(errorReport);
                int noOfTimes = int.Parse(functionArguments[2].Execute(errorReport));

                string indentedText = "";

                if (txt != null && txt.Length >= 1)
                {
                    if (indentType == "TAB")
                        indentedText = txt.PadLeft(txt.Length + noOfTimes, '\t');
                    else // SPACE
                        indentedText = txt.PadLeft(txt.Length + noOfTimes, ' ');

                    result = indentedText;
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
