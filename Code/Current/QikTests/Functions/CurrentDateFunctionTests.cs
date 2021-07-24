using CygSoft.Qik;
using CygSoft.Qik.Functions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using LanguageEngine.Tests.UnitTests.Helpers;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class CurrentDateFunctionTests
    {

        [Test]
        public void Should_Return_Correct_Date_In_Default_Format_When_No_Argument_Specified()
        {
            var funcText = $"currentDate()";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual(DateTime.Now.ToLongDateString(), output);
        }

        [Test]
        public void Should_Return_Correct_Date_In_Default_Format_When_Format_Argument_Specified()
        {
            var funcText = $"currentDate(\"dd/MM/yyyy\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), output);
        }

        [Test]
        public void CurrentDateFunction_RequestDate_ReturnsCurrentDate_1()
        {
            var globalTable = new GlobalTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "dd/MM/yyyy")
            };

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@currentDate", new 
                CurrentDateFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            
            Assert.AreEqual("@currentDate", expressionSymbol.Symbol);
            Assert.AreEqual("@{currentDate}", expressionSymbol.Placeholder);

            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), expressionSymbol.Value);
        }
    }
}
