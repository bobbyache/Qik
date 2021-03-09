using NUnit.Framework;
using LanguageEngine.Tests.UnitTests.Helpers;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class HtmlEncodeFunctionTests
    {

        [Test]
        public void Should_Encode_Correctly()
        {
            var text = @"Hello 'World'";
            var funcText = $"htmlEncode(\"{text}\")";
            var output = TestHelpers.EvaluateFunction(funcText);
            Assert.AreEqual(@"Hello &#39;World&#39;", output);
        }
    }
}