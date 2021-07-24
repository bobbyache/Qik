using CygSoft.Qik;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;

namespace LanguageEngine.Tests.UnitTests.Symbols
{
    [TestFixture]
    public class TextInputSymbolTests
    {
        [Test]
        public void TextInputSymbol_Initialize_InitializesPlaceholder()
        {
            InputSymbol inputSymbol = TestHelpers.CreateInputSymbol_Author();
            Assert.AreEqual("@{authorName}", inputSymbol.Placeholder);
        }
    }
}
