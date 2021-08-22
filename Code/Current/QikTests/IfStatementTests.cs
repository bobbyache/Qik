using CygSoft.Qik;
using CygSoft.Qik.Functions;
using NUnit.Framework;

namespace Qik.LanguageEngine.UnitTests
{
    [TestFixture]
    class IfStatementTests
    {
        [Test]
        public void Should_Be_Expected_Value_For_Simple_Text_Comparison_If_Without_ElseIf_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""1"";

                    @result =>
                        if @val_1 == ""1"" then
                            lowerCase(""GREEN"")
                                                        
                        else
                            lowerCase(""BLACK"")
                    ;
                "
            );

            Assert.AreEqual("green", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_For_Simple_Text_Comparison_Else_Without_ElseIf_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""2"";

                    @result =>
                        if @val_1 == ""1"" then 
                            lowerCase(""GREEN"")
                                                        
                        else
                            lowerCase(""BLACK"")
                    ;
                "
            );

            Assert.AreEqual("black", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_For_Simple_Text_Comparison_If_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""1"";

                    @result =>
                        if @val_1 == ""1"" then
                            lowerCase(""GREEN"")
                            
                        else if @val_1 == ""2"" then
                            lowerCase(""ORANGE"")
                            
                        else if @val_1 == ""2"" then
                            lowerCase(""ORANGE"")
                            
                        else
                            lowerCase(""BLACK"")
                    ;
                "
            );

            Assert.AreEqual("green", terminal.GetValue("@result"));
        }
		
        [Test]
        public void Should_Be_Expected_Value_For_Simple_Text_Comparison_ElseIf_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""2"";

                    @result =>
                        if @val_1 == ""1"" then
                            lowerCase(""GREEN"")
                            
                        else if @val_1 == ""2"" then
                            lowerCase(""ORANGE"")
                            
                        else if @val_1 == ""2"" then
                            lowerCase(""ORANGE"")
                            
                        else
                            lowerCase(""BLACK"")
                    ;
                "
            );

            Assert.AreEqual("orange", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_For_Simple_Text_Comparison_Case_Else_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""-1"";

                    @result =>
                        if @val_1 == ""1"" then
                            lowerCase(""GREEN"")
                            
                        else if @val_1 == ""2"" then
                            lowerCase(""ORANGE"")
                            
                        else if @val_1 == ""2"" then
                            lowerCase(""ORANGE"")
                            
                        else
                            lowerCase(""BLACK"")
                    ;
                "
            );

            Assert.AreEqual("black", terminal.GetValue("@result"));
        }
    }
}
