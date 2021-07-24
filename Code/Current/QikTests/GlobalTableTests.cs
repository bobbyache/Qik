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
        [Category("Qik.GlobalTable")]
        public void Should_Successfully_Add_And_Get_Symbol_Values()
        {
            GlobalTable globalTable = new GlobalTable();

            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", "Rob Blake");

            List<IFunction> functionArguments = new List<IFunction> { new VariableFunction(new FuncInfo("stub", 1, 1), globalTable, "@authorName") };
            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@upperAuthorName", "Upper Author Name", new UpperCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));

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