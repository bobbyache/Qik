using CygSoft.Qik;
using CygSoft.Qik.Console;
using CygSoft.Qik.Functions;
using NUnit.Framework;

namespace Qik.LanguageEngine.UnitTests
{
    [TestFixture]
    class PlaceholderTerminalTests
    {
        [Test]
        public void Should_Get_The_Value_For_A_Placeholder_Symbol()
        {
            var interpreter = new Interpreter();
            var symbolTerminal = interpreter.Interpret(new FunctionFactory(), "@InputVar => \"Hello World\";");
            var terminal = new PlaceholderTerminal("id", symbolTerminal);

            Assert.AreEqual("Hello World", terminal.GetValue("@{InputVar}"));
        }
    }
}