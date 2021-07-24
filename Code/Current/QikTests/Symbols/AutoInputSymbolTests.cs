using CygSoft.Qik;
using NUnit.Framework;

namespace LanguageEngine.Tests.UnitTests.Symbols
{
    [TestFixture]
    public class AutoInputSymbolTests
    {
        [Test]
        public void AutoInputSymbol__Cast_CanCastToIInputFieldInterface()
        {
            var autoInputSymbol = new AutoInputSymbol("@columnA", "Column 1");
            
            Assert.That(autoInputSymbol is IInputField);
        }

        [Test]
        public void AutoInputSymbol_WithDefault()
        {
            
            var autoInputSymbol = new AutoInputSymbol("@columnA", "Column 1");
            
            Assert.AreEqual("@columnA", autoInputSymbol.Symbol);
            Assert.AreEqual("@{columnA}", autoInputSymbol.Placeholder);
            Assert.AreEqual("Column 1", autoInputSymbol.Title);
            Assert.AreEqual(null, autoInputSymbol.DefaultValue);
            Assert.AreEqual(null, autoInputSymbol.Value);
        }
    }
}
