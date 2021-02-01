using CalculationService.Parsers;
using CalculationService.Tests.Utils;
using CalculationService.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationService.Tests.Parsers
{
    [TestClass]
    public class ParenthesisParserTests
    {
        private readonly Parser _parser;

        public ParenthesisParserTests()
        {
            _parser = new ParenthesisParser();
        }

        [TestMethod]
        public void TryParse_RoundBrackets_MustReturnTrue()
        {
            ParenthesisToken token;

            ParserAssert.IsTrue(_parser, "(", 1, out token);
            Assert.IsTrue(token.IsOpen);

            ParserAssert.IsTrue(_parser, ")", 1, out token);
            Assert.IsFalse(token.IsOpen);
        }

        [TestMethod]
        public void TryParse_OtherBrackets_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("[", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("]", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("{", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("}", 0, out _, out _));
        }
    }
}
