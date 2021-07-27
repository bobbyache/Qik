using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class IifFunction : BaseFunction
    {
        private string comparisonOperator = "";

        public IifFunction(IFuncInfo funcInfo, ISymbolTable symbolTable, List<IFunction> functionArguments)
            : base(funcInfo, symbolTable, functionArguments)
        {

        }

        public override string Execute(IErrorReport errorReport)
        {
            if (functionArguments.Count() != 4)
                errorReport.AddError(new CustomError(this.Line, this.Column, "Unexpected number of arguments", this.Name));

            string result = null;
            try
            {
                var leftOperand = functionArguments[0];
                var rightOperand = functionArguments[1];
                var trueExpression = functionArguments[2];
                var falseExpression = functionArguments[3];

                if (comparisonOperator == "==")
                {
                    if (leftOperand.Execute(errorReport) == rightOperand.Execute(errorReport))
                    {
                        return trueExpression.Execute(errorReport);
                    }
                    else
                    {
                        return falseExpression.Execute(errorReport);
                    }
                }
                else if (comparisonOperator == "!=")
                {
                    if (leftOperand.Execute(errorReport) != rightOperand.Execute(errorReport))
                    {
                        return trueExpression.Execute(errorReport);
                    }
                    else
                    {
                        return falseExpression.Execute(errorReport);
                    }
                }
                else
                {
                    throw new Exception("Unidentified operator");
                }
            }
            catch (Exception)
            {
                errorReport.AddError(new CustomError(this.Line, this.Column, "Bad function call.", this.Name));
            }
            return result;
        }

        public void SetOperator(string comparisonOperator)
        {
            this.comparisonOperator = comparisonOperator;
        }
    }
}
