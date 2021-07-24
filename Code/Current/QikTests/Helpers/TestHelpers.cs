using CygSoft.Qik;

namespace LanguageEngine.Tests.UnitTests.Helpers
{
    public class TestHelpers
    {
        internal static string EvaluateFunction(string functionText)
        {
            var interpreter = new Interpreter();
            var expression = TestHelpers.BuildExpressionForFunction(functionText);

            interpreter.Interpret(expression);
            var val = interpreter.GetValueOfSymbol("@output");

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
