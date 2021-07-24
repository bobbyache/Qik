using CygSoft.Qik;
using CygSoft.Qik.Functions;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    public class ProperCaseFunctionTests
    {
        [Test]
        public void ProperCaseFunction_InputUpperCase_OutputsProperCase_1()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            var globalTable = new GlobalTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "LITERAL TEXT")
            };

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@toProperCase", "Proper Case Function", true, true, 
                new ProperCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
                
            Assert.AreEqual("@toProperCase", expressionSymbol.Symbol);
            Assert.AreEqual("@{toProperCase}", expressionSymbol.Placeholder);
            Assert.AreEqual("Proper Case Function", expressionSymbol.Title);

            Assert.AreEqual("Literal Text", expressionSymbol.Value);
        }

        [Test]
        public void ProperCaseFunction_InputUpperCase_OutputsProperCase()
        {
            var funcText = $"properCase(\"PROPERCASE TEXT\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual("Propercase Text", output);
        }
    }
}
