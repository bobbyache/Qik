using CygSoft.Qik;
using CygSoft.Qik.Functions;

namespace QikTests
{
    public class TestHelpers
    {
        internal static string EvaluateFunction(string functionText)
        {
            var interpreter = new Interpreter();
            var expression = TestHelpers.BuildExpressionForFunction(functionText);

            var terminal = interpreter.Interpret(new FunctionFactory(), expression);
            var val = terminal.GetValue("@output");

            return val;
        }

        internal static InputSymbol CreateInputSymbol_Author(string symbol = "@authorName")
        {
            var inputSymbol = new InputSymbol(symbol);
            return inputSymbol;
        }

        private static string BuildExpressionForFunction(string functionText)
        {
            return "@output => " + functionText + ";";
        }
    }
}
