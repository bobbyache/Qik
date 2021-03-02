﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class PadRightFunction : BaseFunction
    {
        public PadRightFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<IFunction> functionArguments) : base(funcInfo, scopeTable, functionArguments)
        {

        }

        public override string Execute(IErrorReport errorReport)
        {
            if (functionArguments.Count() != 3)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Too many arguments", this.Name));

            string result = null;
            try
            {
                string txt = functionArguments[0].Execute(errorReport);
                char character = functionArguments[1].Execute(errorReport)[0];
                int amount = int.Parse(functionArguments[2].Execute(errorReport));

                if (txt != null && txt.Length >= 1)
                {
                    result = txt.PadRight(amount, character);
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
