﻿using CygSoft.Qik;
using CygSoft.Qik.Functions;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    public class DoubleQuotedFunctionTests
    {
        [Test]
        public void DoubleQuoteFunction_InputText_OutputsDoubleQuotedText()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            var globalTable = new SymbolTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction("stub", "literal text")
            };

            var expressionSymbol = new ExpressionSymbol("@classInstance",  
                new DoubleQuoteFunction("stub", functionArguments));

            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("\"literal text\"", expressionSymbol.Value);
        }

        [Test]
        public void DoubleQuoteFunction_Old_InputText_OutputsDoubleQuotedText()
        {
            var funcText = $"doubleQuotes(\"quote me\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual("\"quote me\"", output);
        }

        [Test]
        public void DoubleQuoteFunction_New_InputText_OutputsDoubleQuotedText()
        {
            var funcText = $"doubleQuote(\"quote me\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual("\"quote me\"", output);
        }
    }
}