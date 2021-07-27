﻿using CygSoft.Qik;
using CygSoft.Qik.Functions;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class ConcatenateFunctionTests
    {
        [Test]
        public void ConcatenateFunction_Input3Strings_ConcatenatesToSingleString()
        {
            var concatExpression = "\"hello\" + \" \" + \"world\"";
            var output = TestHelpers.EvaluateFunction(concatExpression);
            Assert.AreEqual("hello world", output);
        }
    }
}
