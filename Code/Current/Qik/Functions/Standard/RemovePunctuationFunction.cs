using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class RemovePunctuationFunction : BaseFunction
    {
        public RemovePunctuationFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, List<IFunction> functionArguments)
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
                    result = txt.Where(c => !char.IsPunctuation(c)).Aggregate("", (current, c) => current + c);
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


// http://stackoverflow.com/questions/421616/how-can-i-strip-punctuation-from-a-string
//string s = "sxrdct?fvzguh,bij.";
//var sb = new StringBuilder();

//foreach (char c in s)
//{
//   if (!char.IsPunctuation(c))
//      sb.Append(c);
//}

//s = sb.ToString();