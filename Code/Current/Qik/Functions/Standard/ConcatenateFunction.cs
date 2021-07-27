using System;
using System.Collections.Generic;

namespace CygSoft.Qik.Functions
{
    public class ConcatenateFunction : BaseFunction
    {
        private readonly List<IFunction> functions = new List<IFunction>();

        public ConcatenateFunction(IFuncInfo funcInfo, ISymbolTable symbolTable)
            : base(funcInfo, symbolTable)
        {
            this.symbolTable = symbolTable;
        }

        public override string Execute(IErrorReport errorReport)
        {
            string result = null;
            try
            {
                foreach (BaseFunction func in functions)
                {
                    result += func.Execute(errorReport);
                }
            }
            catch (Exception)
            {
                errorReport.AddError(new CustomError(this.Line, this.Column, "Concatenation error.", this.Name));
            }
            return result;
        }
        public void AddFunction(IFunction func)
        {
            functions.Add(func);
        }

    }
}
