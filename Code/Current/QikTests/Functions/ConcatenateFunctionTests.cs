using CygSoft.Qik;
using CygSoft.Qik.Functions;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class ConcatenateFunctionTests
    {

        //TODO: Wherever this message is in the function tests look to convert to the new form of the function test see 
            // var output = TestHelpers.EvaluateFunction(funcText);

        // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW
        [Test]
        public void ConcatenateFunction_Input3Strings_ConcatenatesToSingleString_1()
        {
            var globalTable = new GlobalTable();

            var concatFunc = new ConcatenateFunction(new FuncInfo("stub", 1, 1), globalTable);

            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "hello"));
            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, " "));
            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "world"));

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@concat", "Concatenated String", concatFunc);

            Assert.AreEqual("@concat", expressionSymbol.Symbol);
            Assert.AreEqual("@{concat}", expressionSymbol.Placeholder);

            Assert.AreEqual("hello world", expressionSymbol.Value);
        }

        [Test]
        public void ConcatenateFunction_Input3Strings_ConcatenatesToSingleString()
        {
            var concatExpression = "\"hello\" + \" \" + \"world\"";
            var output = TestHelpers.EvaluateFunction(concatExpression);
            Assert.AreEqual("hello world", output);
        }
    }
}
