using CygSoft.Qik;
using CygSoft.Qik.Functions;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class ReplaceFunctionTests
    {
        [Test]
        public void ReplaceFunction_InputText_ReplacesCorrectly_1()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            var globalTable = new GlobalTable();

            var functionArguments = new List<IFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "Dashboard Usage"));
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, " "));
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "_"));

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance",
                new ReplaceFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Dashboard_Usage", expressionSymbol.Value);
        }

        [Test]
        public void ReplaceFunction_InputText_ReplacesCorrectly()
        {
            var funcText = $"replace(\"literal text ya all\", \" \", \"_\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual("literal_text_ya_all", output);
        }
    }
}
