using CygSoft.Qik;
using NUnit.Framework;
using Qik.LanguageEngine.IntegrationTests.Helpers;
using System;

namespace Qik.LanguageEngine.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void ScriptExamples_CreateMultilineScriptInExpression_OutputsCorrectly()
        {
            IInterpreter interpreter = new Interpreter();
            interpreter.Interpret(FileHelpers.ReadText("MultiLine.qik"));

            IGenerator generator = new Generator();
            string output = generator.Generate(interpreter, FileHelpers.ReadText("MultiLine.tpl"));

            Assert.AreEqual(FileHelpers.ReadText("MultiLine.out"), output);
        }
    }
}
