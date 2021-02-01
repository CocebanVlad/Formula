using CalculationService.Parsers;
using CalculationService.Tests.Utils;
using CalculationService.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationService.Tests.Parsers
{
    [TestClass]
    public class SeparatorParserTests
    {
        private readonly Parser _parser;

        public SeparatorParserTests()
        {
            _parser = new SeparatorParser();
        }

        [TestMethod]
        public void TryParse_Comma_MustReturnTrue()
        {
            ParserAssert.IsTrue<SeparatorToken>(_parser, ",", 1, out _);
        }

        [TestMethod]
        public void TryParse_Semicolon_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse(";", 0, out _, out _));
        }
    }
}
