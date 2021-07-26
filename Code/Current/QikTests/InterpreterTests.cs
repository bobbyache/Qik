using CygSoft.Qik;
using NUnit.Framework;
using Moq;

namespace Qik.LanguageEngine.UnitTests
{
    [TestFixture]
    class InterpreterTests
    {
        [Test]
        public void Should_Validate_Script()
        {
            var syntaxValidatorMock = new Mock<ISyntaxValidator>();
            var interpreterEngineMock = new Mock<IInterpreterEngine>();

            var interpreter = new Interpreter(syntaxValidatorMock.Object, interpreterEngineMock.Object);
            interpreter.Interpret("// Script text");

            syntaxValidatorMock.Verify(validator => validator.Validate(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Should_Interpret_Instructions_If_Syntax_Has_No_Errors()
        {
            var syntaxValidatorMock = new Mock<ISyntaxValidator>();
            syntaxValidatorMock.Setup(validator => validator.HasErrors).Returns(false);

            var interpreterEngineMock = new Mock<IInterpreterEngine>();

            var interpreter = new Interpreter(syntaxValidatorMock.Object, interpreterEngineMock.Object);
            interpreter.Interpret("// Script text has no errors");

            interpreterEngineMock.Verify(engine => engine.Interpret(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Should_Not_Interpret_Instructions_If_Syntax_Has_Errors()
        {
            var syntaxValidatorMock = new Mock<ISyntaxValidator>();
            syntaxValidatorMock.Setup(validator => validator.HasErrors).Returns(true);

            var interpreterEngineMock = new Mock<IInterpreterEngine>();

            var interpreter = new Interpreter(syntaxValidatorMock.Object, interpreterEngineMock.Object);
            interpreter.Interpret("// Script text has errors");

            interpreterEngineMock.Verify(engine => engine.Interpret(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Should_Read_IifFunction()
        {
            IInterpreter interpreter = new Interpreter();
            interpreter.Interpret(
                @"
                    @IssueNumber => ""253"";
                    @TestDec => @IssueNumber == ""253"" ? ""true"" : ""false"";
                "
            );



            Assert.AreEqual("true", interpreter.GetValueOfSymbol("@TestDec"));
        }

        [Test]
        public void Should_Read_IifFunction_Another()
        {
            IInterpreter interpreter = new Interpreter();
            interpreter.Interpret(
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? ""happy"" : ""sad"";
                "
            );

            Assert.AreEqual("happy", interpreter.GetValueOfSymbol("@TestDec"));
        }

        [Test]
        public void Should_Read_IifFunction_Another_()
        {
            IInterpreter interpreter = new Interpreter();
            interpreter.Interpret(
                @"
                    @Entity => ""EmailAttribute"";
                    @TestDec => camelCase(@Entity) == ""emailAttribute"" ? properCase(""happy"") : properCase(""sad"");
                "
            );

            Assert.AreEqual("Happy", interpreter.GetValueOfSymbol("@TestDec"));
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
