using CygSoft.Qik;
using NUnit.Framework;
using Qik.LanguageEngine.IntegrationTests.Helpers;
using System;

namespace Qik.LanguageEngine.IntegrationTests
{
    [TestFixture]
    public class InputTests
    {
        [Test]
        public void Should_Create_An_Input_Variable_With_Provided_Text()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret("@InputVar => \"Hello World\";");
            var value = terminal.GetValue("@InputVar");

            Assert.AreEqual("Hello World", value);
        }

        [Test]
        public void Should_Create_An_Input_Variable_With_Provided_Text_With_No_Spaces()
        {
            IInterpreter interpreter = new Interpreter();

            var terminal = interpreter.Interpret("@InputVar=>\"Hello World\";");
            var value = terminal.GetValue("@InputVar");

            Assert.AreEqual("Hello World", value);
        }
    }
}