﻿using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class ProperCaseFunction : BaseFunction
    {
        public ProperCaseFunction(FuncInfo funcInfo, GlobalTable scopeTable, List<BaseFunction> functionArguments)
            : base(funcInfo, scopeTable, functionArguments)
        {

        }

        public override string Execute(Infrastructure.IErrorReport errorReport)
        {
            if (functionArguments.Count() != 1)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Too many arguments", this.Name));

            string result = null;
            try
            {
                string txt = functionArguments[0].Execute(errorReport);

                if (txt != null && txt.Length >= 1)
                {
                    CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                    result = cultureInfo.TextInfo.ToTitleCase(txt.ToLower());
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
