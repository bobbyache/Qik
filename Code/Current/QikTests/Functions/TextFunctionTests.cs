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

            var globalTable = new GlobalTable();

            var literalText = "Rob Blake";
            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@authorName", "Author Name", true, true, 
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, literalText));
            
            Assert.AreEqual("@authorName", expressionSymbol.Symbol);
            Assert.AreEqual("@{authorName}", expressionSymbol.Placeholder);
            Assert.AreEqual("Author Name", expressionSymbol.Title);

            Assert.AreEqual("Rob Blake", expressionSymbol.Value);
        }
    }
}
