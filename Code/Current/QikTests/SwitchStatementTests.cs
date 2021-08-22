using CygSoft.Qik;
using CygSoft.Qik.Functions;
using NUnit.Framework;

namespace Qik.LanguageEngine.UnitTests
{
    [TestFixture]
    class SwitchStatementTests
    {
		
        [Test]
        public void Should_Be_Expected_Value_For_Simple_Text_Comparison_Case_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @testVal => ""Green"";
                    @result =>
                        switch @testVal
                            case ""Yellow"" : ""YELLOW""
                            case ""Green"" : ""GREEN""
                            else
                                ""RED""
                    ;
                "
            );

            Assert.AreEqual("GREEN", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_For_Simple_Text_Comparison_Else_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @testVal => ""Blue"";
                    @result =>
                        switch @testVal
                            case ""Yellow"" : ""YELLOW""
                            case ""Green"" : ""GREEN""
                            else
                                ""RED""
                    ;
                "
            );

            Assert.AreEqual("RED", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_For_Simple_Text_Comparison_Else_Check_After_SetValue()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @testVal => ""Blue"";
                    @result =>
                        switch @testVal
                            case ""Yellow"" : ""YELLOW""
                            case ""Green"" : ""GREEN""
                            else
                                ""RED""
                    ;
                "
            );

            terminal.SetValue("@testVal", "Yellow");

            Assert.AreEqual("YELLOW", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_For_Case_Ternary_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""Blue"";
                    @val_2 => ""GRAVY"";

                    @result =>
                        switch @val_1
                            case ""Yellow"" : ""YELLOW""
                            case ""Blue"" : lowerCase(@val_2) == ""gravy"" ? upperCase(""happy"") : upperCase(""sad"")
                            else
                                ""RED""
                    ;
                "
            );

            Assert.AreEqual("HAPPY", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_For_Switch_Function_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""Blue"";
                    @val_2 => ""GRAVY"";

                    @result =>
                        switch upperCase(@val_1)
                            case ""green"" : ""green""
                            case ""BLUE"" : lowerCase(@val_2) == ""gravy"" ? upperCase(""happy"") : upperCase(""sad"")
                            else
                                ""RED""
                    ;
                "
            );

            Assert.AreEqual("HAPPY", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_For_Switch_And_Else_Function_Check()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""red"";
                    @val_2 => ""GRAVY"";

                    @result =>
                        switch upperCase(@val_1)
                            case ""GREEN"" : ""green""
                            case ""BLUE"" : ""blue""
                            else
                                lowerCase(@val_2) == ""gravy"" ? upperCase(""happy"") : upperCase(""sad"")
                    ;
                "
            );

            Assert.AreEqual("HAPPY", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_When_Matches_Case_Using_Concatenation()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""Blue"";

                    @result =>
                        switch upperCase(@val_1)
                            case ""GREEN"" : lowerCase(""Green"") + "" grass""
                            case ""BLUE"" : lowerCase(""Blue"") + "" grass""
                            else lowerCase(""Yellow"") + "" grass""
                    ;
                "
            );

            Assert.AreEqual("blue grass", terminal.GetValue("@result"));
        }

        [Test]
        public void Should_Be_Expected_Value_When_Matches_Else_Using_Concatenation()
        {
            var interpreter = new Interpreter();
            var terminal = interpreter.Interpret(new FunctionFactory(), 
                @"
                    @val_1 => ""Orange"";

                    @result =>
                        switch upperCase(@val_1)
                            case ""GREEN"" : lowerCase(""Green"") + "" grass""
                            case ""BLUE"" : lowerCase(""Blue"") + "" grass""
                            else lowerCase(""Yellow"") + "" grass""
                    ;
                "
            );

            Assert.AreEqual("yellow grass", terminal.GetValue("@result"));
        }
    }
}
