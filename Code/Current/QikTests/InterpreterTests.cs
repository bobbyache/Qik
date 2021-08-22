﻿using CygSoft.Qik;
using CygSoft.Qik.Functions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Qik.LanguageEngine.UnitTests
{
    [TestFixture]
    class InterpreterTests
    {
        [Test]
        public void Should_Create_An_Input_Variable_With_Provided_Text()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), "@InputVar => \"Hello World\";");
            var value = terminal.GetValue("@InputVar");

            Assert.AreEqual("Hello World", value);
        }

        [Test]
        public void Should_Create_An_Input_Variable_With_Provided_Text_With_No_Spaces()
        {
            IInterpreter interpreter = new Interpreter();

            var terminal = interpreter.Interpret(new FunctionFactory(), "@InputVar=>\"Hello World\";");
            var value = terminal.GetValue("@InputVar");

            Assert.AreEqual("Hello World", value);
        }
    }
}
