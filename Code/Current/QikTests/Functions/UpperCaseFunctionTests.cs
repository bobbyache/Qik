﻿using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Functions.Core;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;
using CygSoft.Qik.LanguageEngine.Symbols;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    public class UpperCaseFunctionTests
    {
        [Test]
        public void UpperCaseFunction_InputLower_OutputsUpperCase_1()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            var globalTable = new GlobalTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "literaltext")
            };

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", "Description", true, true, 
                new UpperCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("LITERALTEXT", expressionSymbol.Value);
        }

        [Test]
        public void UpperCaseFunction_InputLower_OutputsUpperCase()
        {
            var funcText = $"upperCase(\"lowercase text\")";
            var output = TestHelpers.EvaluateCompilerFunction(funcText);
            Assert.AreEqual("LOWERCASE TEXT", output);
        }
    }
}
