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

        internal static TextInputSymbol CreateTextInputSymbol_Author(string symbol = "@authorName", string title = "Author Name", string defaultValue = null)
        {
            var textInputSymbol = new TextInputSymbol(symbol, title, defaultValue);
            return textInputSymbol;
        }

        private static string BuildExpressionForFunction(string functionText)
        {
            return "@output = expression [Title=\"Expression Text\"] { return " + functionText + "; };";
        }
    }
}
