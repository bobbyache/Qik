using CygSoft.Qik;
using CygSoft.Qik.Functions;
using NUnit.Framework;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class TextFunctionTests
    {
        [Test]
        public void BasicTextFunction_InputText_OutputsText()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            var globalTable = new SymbolTable();

            var literalText = "Rob Blake";
            var expressionSymbol = new ExpressionSymbol("@authorName",
                new TextFunction("stub", literalText));
            
            Assert.AreEqual("@authorName", expressionSymbol.Symbol);
            Assert.AreEqual("Rob Blake", expressionSymbol.Value);
        }
    }
}
