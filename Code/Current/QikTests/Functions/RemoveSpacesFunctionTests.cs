using CygSoft.Qik;
using CygSoft.Qik.Functions;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class RemoveSpacesFunctionTests
    {
        [Test]
        public void RemoveSpacesFunction_InputSpacedText_RemovesSpaces_1()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            var globalTable = new GlobalTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "literal text")
            };

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", true, true, 
                new RemoveSpacesFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literaltext", expressionSymbol.Value);
        }

        [Test]
        public void RemoveSpacesFunction_InputSpacedText_RemovesSpaces()
        {
            var funcText = $"removeSpaces(\"literal text ya all\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual("literaltextyaall", output);
        }
    }
}
