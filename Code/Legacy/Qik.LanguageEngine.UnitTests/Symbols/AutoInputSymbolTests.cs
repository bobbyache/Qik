﻿using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Symbols;
using NUnit.Framework;

namespace LanguageEngine.Tests.UnitTests.Symbols
{
    [TestFixture]
    [Category("Qik")]
    [Category("Qik.Symbol")]
    [Category("Tests.UnitTests")]
    public class AutoInputSymbolTests
    {
        [Test]
        public void AutoInputSymbol__Cast_CanCastToIInputFieldInterface()
        {
            AutoInputSymbol autoInputSymbol = new AutoInputSymbol("@columnA", "Column 1", "Description for Column 1");
            Assert.That(autoInputSymbol is IInputField);
        }

        [Test]
        public void AutoInputSymbol_WithDefault()
        {
            
            AutoInputSymbol autoInputSymbol = new AutoInputSymbol("@columnA", "Column 1", "Description for Column 1");
            Assert.AreEqual("@columnA", autoInputSymbol.Symbol);
            Assert.AreEqual("@{columnA}", autoInputSymbol.Placeholder);
            Assert.AreEqual("Column 1", autoInputSymbol.Title);
            Assert.AreEqual(null, autoInputSymbol.DefaultValue);
            Assert.AreEqual("Description for Column 1", autoInputSymbol.Description);
            Assert.AreEqual(null, autoInputSymbol.Value);
        }
    }
}
