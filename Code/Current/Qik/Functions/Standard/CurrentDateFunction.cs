using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class CurrentDateFunction : BaseFunction
    {
        public CurrentDateFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<IFunction> functionArguments)
            : base(funcInfo, scopeTable, functionArguments)
        {

        }

        public override string Execute(IErrorReport errorReport)
        {
            if (functionArguments.Count() > 1)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Unexpected number of arguments", this.Name));

            string result = null;
            try
            {
                if (functionArguments.Count() == 1) 
                {
                    string dateFormatText = functionArguments[0].Execute(errorReport);

                    if (dateFormatText != null && dateFormatText.Length >= 1)
                    {
                        string dateText = DateTime.Now.ToString(dateFormatText);
                        result = dateText;
                    }
                }
                else
                {
                    result = DateTime.Now.ToLongDateString();
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
