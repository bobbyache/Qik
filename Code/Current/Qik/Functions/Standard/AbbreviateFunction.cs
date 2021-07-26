using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace CygSoft.Qik.Functions
{
    public class AbbreviateFunction : BaseFunction
    {

        public AbbreviateFunction(IFuncInfo funcInfo, IGlobalTable scopeTable, List<IFunction> functionArguments)
            : base(funcInfo, scopeTable, functionArguments)
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

                if (!string.IsNullOrWhiteSpace(txt))
                {
                    var builder = new StringBuilder();

                    foreach (var chr in txt.ToCharArray())
                    {
                        if (char.IsUpper(chr))
                        {
                            builder.Append(' ');
                            builder.Append(chr);
                    
                        }
                        else if (chr == '_')
                        {
                            builder.Append(' ');
                        }
                        else
                        {
                            builder.Append(chr);
                        }
                    }
                    
                    var results = builder.ToString()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(str => str[0]).ToArray();
                    
                    result = new string(results);
                    return result;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                errorReport.AddError(new CustomError(this.Line, this.Column, "Bad function call.", this.Name));
            }
            return result;
        }
    }
}
