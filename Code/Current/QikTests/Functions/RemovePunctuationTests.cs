using CygSoft.Qik;
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
            var globalTable = new SymbolTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction("stub", "LITERAL?!..TEXT.")
            };

            var expressionSymbol = new ExpressionSymbol("@removePunctuation", 
                new RemovePunctuationFunction("stub", functionArguments));
            
            Assert.AreEqual("@removePunctuation", expressionSymbol.Symbol);
            Assert.AreEqual("LITERALTEXT", expressionSymbol.Value);
        }

        [Test]
        public void RemovePunctuationFunction_InputPunctuatedText_OutputPunctuationRemoved()
        {
            var funcText = $"removePunctuation(\"LITERAL?!..TEXT.\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual("LITERALTEXT", output);
        }
    }
}
