﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CygSoft.Qik.Functions
{
    public class HtmlEncodeFunction : BaseFunction
    {
        public HtmlEncodeFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<IFunction> functionArguments) : base(funcInfo, scopeTable, functionArguments)
        {

        }
        public override string Execute(IErrorReport errorReport)
        {
            if (functionArguments.Count() != 1)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Too many arguments", this.Name));

            string result = null;
            try
            {
                string txt = functionArguments[0].Execute(errorReport);

                if (txt != null && txt.Length >= 1)
                {
                    result = HttpUtility.HtmlEncode(txt); 
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
