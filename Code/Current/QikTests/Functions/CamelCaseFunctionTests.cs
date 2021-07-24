using CygSoft.Qik;
using CygSoft.Qik.Functions;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    public class CamelCaseFunctionTests
    {
        [Test]
        public void CamelCaseFunction_InputPascalCase_OutputsCamelCase_1()
        {
            var globalTable = new GlobalTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "LiteralText")
            };

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", true, true, 
                new CamelCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literalText", expressionSymbol.Value);
        }

        [Test]
        public void CamelCaseFunction_InputPascalCase_OutputsCamelCase()
        {
            var funcText = $"camelCase(\"LiteralText\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual("literalText", output);
        }
    }
}
