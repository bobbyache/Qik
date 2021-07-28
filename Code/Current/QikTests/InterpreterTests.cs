using CygSoft.Qik;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace Qik.LanguageEngine.UnitTests
{
    [TestFixture]
    class InterpreterTests
    {
        // [Test]
        // public void Should_Validate_Script()
        // {
        //     var syntaxValidatorMock = new Mock<ISyntaxValidator>();

        //     var interpreter = new Interpreter();
        //     interpreter.Interpret("// Script text");

        //     syntaxValidatorMock.Verify(validator => validator.Validate(It.IsAny<string>()), Times.Once);
        // }

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
        
        // [Test]
        // public void Should_Interpret_Instructions_If_Syntax_Has_No_Errors()
        // {
        //     var syntaxValidatorMock = new Mock<ISyntaxValidator>();
        //     syntaxValidatorMock.Setup(validator => validator.HasErrors).Returns(false);

        //     var interpreterEngineMock = new Mock<IInterpreterEngine>();

        //     var interpreter = new Interpreter();
        //     interpreter.Interpret("// Script text has no errors");

        //     interpreterEngineMock.Verify(engine => engine.Interpret(It.IsAny<string>()), Times.Once);
        // }

        // [Test]
        // public void Should_Not_Interpret_Instructions_If_Syntax_Has_Errors()
        // {
        //     var syntaxValidatorMock = new Mock<ISyntaxValidator>();
        //     syntaxValidatorMock.Setup(validator => validator.HasErrors).Returns(true);

        //     var interpreterEngineMock = new Mock<IInterpreterEngine>();

        //     var interpreter = new Interpreter(syntaxValidatorMock.Object, interpreterEngineMock.Object);
        //     interpreter.Interpret("// Script text has errors");

        //     interpreterEngineMock.Verify(engine => engine.Interpret(It.IsAny<string>()), Times.Never);
        // }

        [Test]
        public void Should_Read_IifFunction()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(
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
            var terminal = interpreter.Interpret(
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
            var terminal = interpreter.Interpret(
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
            var terminal = interpreter.Interpret(
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
            var terminal = interpreter.Interpret(
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
            var terminal = interpreter.Interpret(
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
            var terminal = interpreter.Interpret(
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
            var terminal = interpreter.Interpret(
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
            var terminal = interpreter.Interpret(
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? ""happy"" : ""sad"";
                "
            );

            Assert.AreEqual(2, terminal.Symbols.Length);
        }

    //
    // TODO (Rob) Reinstate tests like this based on new syntax structure.
    // Refresh yourself on how error handling works...
    
    //     [Test]
    //     public void Should_Fire_SyntaxErrorDetected_When_Interpreted_With_Incorrect_Title_Case()
    //     {
    //         var wasCalled = false;
    //         var interpreter = new Interpreter();
    //         interpreter.CompileError += (s, e) => wasCalled = true;

    //         interpreter.Interpret("@dataType = text[title=\"5.Field Datatype)\", Description=\"The datatype for the field (column).\"];");

    //         Assert.IsTrue(wasCalled, "Expect that CompileError event is fired when a syntax error is discovered.");
    //     }

    //     [Test]
    //     public void Should_Fire_SyntaxErrorDetected_When_Interpreted_With_Incorrect_Description_Case()
    //     {
    //         var wasCalled = false;
    //         var interpreter = new Interpreter();

    //         interpreter.CompileError += (s, e) =>
    //         {
    //             wasCalled = true;
    //         };

    //         interpreter.Interpret("@dataType = Text[title=\"5.Field Datatype)\", description=\"The datatype for the field (column).\"];");

    //         Assert.IsTrue(wasCalled, "Expect that CompileError event is fired when a syntax error is discovered.");
    //     }
    }
}
