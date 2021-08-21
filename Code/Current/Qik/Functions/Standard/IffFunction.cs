using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.Functions
{
    public class IifFunction : BaseFunction
    {
        private string comparisonOperator = "";

        public IifFunction(string name, List<IFunction> functionArguments)
            : base(name, functionArguments)
        {

        }

        public override string Execute()
        {
            if (functionArguments.Count() != 4)
                throw new Exception("Unexpected number of function arguments");

            try
            {
                var leftOperand = functionArguments[0];
                var rightOperand = functionArguments[1];
                var trueExpression = functionArguments[2];
                var falseExpression = functionArguments[3];

                if (comparisonOperator == "==")
                {
                    if (leftOperand.Execute() == rightOperand.Execute())
                    {
                        return trueExpression.Execute();
                    }
                    else
                    {
                        return falseExpression.Execute();
                    }
                }
                else if (comparisonOperator == "!=")
                {
                    if (leftOperand.Execute() != rightOperand.Execute())
                    {
                        return trueExpression.Execute();
                    }
                    else
                    {
                        return falseExpression.Execute();
                    }
                }
                else
                {
                    throw new Exception("Unidentified operator");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Unspecified function construction error.", exception);
            }
        }

        public void SetOperator(string comparisonOperator)
        {
            this.comparisonOperator = comparisonOperator;
        }
    }
}
