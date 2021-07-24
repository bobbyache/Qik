using CygSoft.Qik;
using CygSoft.Qik.Functions;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests
{
    [TestFixture]
    public class GlobalTableTests
    {
        [Test]
        public void Should_Not_Add_To_Placeholders_When_IsPlaceholder_Not_Set()
        {
            GlobalTable globalTable = new GlobalTable();

            List<IFunction> functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "dd/MM/yyyy")
            };

            CurrentDateFunction currentDateFunction = new CurrentDateFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments);
            UpperCaseFunction upperCaseFunction = new UpperCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments);


            ExpressionSymbol expressionSymbol1 = new ExpressionSymbol(new ErrorReport(), "@currentDate", "Current Date", false, true, currentDateFunction);
            ExpressionSymbol expressionSymbol2 = new ExpressionSymbol(new ErrorReport(), "@camelCase", "Camel Cased", true, true, upperCaseFunction);

            globalTable.AddSymbol(expressionSymbol1);
            globalTable.AddSymbol(expressionSymbol2);

            // Here is the check that the Placeholder was never created.
            Assert.AreEqual(1, globalTable.Placeholders.Length);
            Assert.AreEqual("@{camelCase}", globalTable.Placeholders[0]);

            Assert.AreEqual("DD/MM/YYYY", globalTable.GetValueOfSymbol("@camelCase"));
        }

                [Test]
        [Category("Qik.GlobalTable")]
        public void Should_Successfully_Add_And_Get_Symbol_Values()
        {
            GlobalTable globalTable = new GlobalTable();

            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", "Rob Blake", true);

            List<IFunction> functionArguments = new List<IFunction> { new VariableFunction(new FuncInfo("stub", 1, 1), globalTable, "@authorName") };
            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@upperAuthorName", "Upper Author Name", true, true, new UpperCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));

            globalTable.AddSymbol(textInputSymbol);
            globalTable.AddSymbol(expressionSymbol);

            string textOutput_A = globalTable.GetValueOfSymbol("@authorName");
            string exprOutput_A = globalTable.GetValueOfSymbol("@upperAuthorName");

            globalTable.Input("@authorName", "John Doe");

            string textOutput_B = globalTable.GetValueOfSymbol("@authorName");
            string exprOutput_B = globalTable.GetValueOfSymbol("@upperAuthorName");

            Assert.AreEqual("Rob Blake", textOutput_A);
            Assert.AreEqual("ROB BLAKE", exprOutput_A);

            Assert.AreEqual("John Doe", textOutput_B);
            Assert.AreEqual("JOHN DOE", exprOutput_B);
        }
    }
}