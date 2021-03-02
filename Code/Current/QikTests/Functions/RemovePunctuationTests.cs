﻿using CygSoft.Qik;
using CygSoft.Qik.Functions;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    public class RemovePunctuationTests
    {
        [Test]
        public void RemovePunctuationFunction_InputPunctuatedText_OutputPunctuationRemoved_1()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW
            var globalTable = new GlobalTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "LITERAL?!..TEXT.")
            };

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@removePunctuation", "Remove Punctuation Function", "Remove Punctuation Function", true, true, 
                new RemovePunctuationFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            
            Assert.AreEqual("@removePunctuation", expressionSymbol.Symbol);
            Assert.AreEqual("@{removePunctuation}", expressionSymbol.Placeholder);
            Assert.AreEqual("Remove Punctuation Function", expressionSymbol.Title);

            Assert.AreEqual("LITERALTEXT", expressionSymbol.Value);
        }

        [Test]
        public void RemovePunctuationFunction_InputPunctuatedText_OutputPunctuationRemoved()
        {
            var funcText = $"removePunctuation(\"LITERAL?!..TEXT.\")";
            var output = TestHelpers.EvaluateCompilerFunction(funcText);
            Assert.AreEqual("LITERALTEXT", output);
        }
    }
}
