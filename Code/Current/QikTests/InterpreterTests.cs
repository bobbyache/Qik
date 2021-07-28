using CygSoft.Qik;
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
        
        [Test]
        public void Should_Read_IifFunction()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @IssueNumber => ""253"";
                    @TestDec => @IssueNumber == ""253"" ? ""true"" : ""false"";
                "
            );



            Assert.AreEqual("true", terminal.GetValue("@TestDec"));
        }

        [Test]
        public void Should_Read_IifFunction_Another()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? ""happy"" : ""sad"";
                "
            );

            Assert.AreEqual("happy", terminal.GetValue("@TestDec"));
        }

        [Test]
        public void Should_Read_IifFunction_Another_()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? properCase(""happy"") : properCase(""sad"");
                "
            );

            Assert.AreEqual("Happy", terminal.GetValue("@TestDec"));
        }

        [Test]
        public void Should_Read_IifFunction_Another__()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @Entity => ""EmailAttribute"";
                    @ExtraCheck => ""extra check"";
                    @TestDec => @Entity == ""OtherAttribute"" ? """"
                        : @ExtraCheck == ""extra check"" ? ""happy"" : ""sad""
                    ;
                "
            );

            Assert.AreEqual("happy", terminal.GetValue("@TestDec"));
        }

        [Test]
        public void Should_Read_Value_Of_Original_iif_Interpreted_Input()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? ""happy"" : ""sad"";
                "
            );

            Assert.AreEqual("happy", terminal.GetValue("@TestDec"));
        }

        [Test]
        public void Should_Read_Value_Of_Updated_iif_Interpreted_Input()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? ""happy"" : ""sad"";
                "
            );

            terminal.SetValue("@Entity", "MailAttribute");

            Assert.AreEqual("sad", terminal.GetValue("@TestDec"));
        }

        [Test]
        public void Should_Throw_Exception_When_Trying_To_Update_A_Non_Input_Symbol()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? ""happy"" : ""sad"";
                "
            );

            Assert.Throws<KeyNotFoundException>(() => terminal.SetValue("@TestSymbol", "MailAttribute"), "Attempting to access a non-input symbol should throw a KeyNotFoundException");
        }

        [Test]
        public void Should_Not_Return_Non_Input_Symbol_In_List_Of_InputSymbols()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? ""happy"" : ""sad"";
                "
            );

            Assert.AreEqual(1, terminal.InputSymbols.Length);
            Assert.AreNotEqual("@TestDec", terminal.InputSymbols[0]);
        }

        [Test]
        public void Should_Return_All_Symbols()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? ""happy"" : ""sad"";
                "
            );

            Assert.AreEqual(2, terminal.Symbols.Length);
        }
    }
}
