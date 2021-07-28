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

            var globalTable = new SymbolTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction("stub", "literal text")
            };

            var expressionSymbol = new ExpressionSymbol("@classInstance",
                new RemoveSpacesFunction("stub", functionArguments));
            
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
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
