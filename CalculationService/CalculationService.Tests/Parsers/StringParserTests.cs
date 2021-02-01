using CalculationService.Exceptions;
using CalculationService.Parsers;
using CalculationService.Tests.Utils;
using CalculationService.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationService.Tests.Parsers
{
    [TestClass]
    public class StringParserTests
    {
        private readonly Parser _parser;

        public StringParserTests()
        {
            _parser = new StringParser();
        }

        [TestMethod]
        public void TryParse_Str_MustReturnTrue()
        {
            ParserAssert.IsTrue<StringToken>(_parser, "\"hello world\"", 13, out _);
            ParserAssert.IsTrue<StringToken>(_parser, "\'hello world\'", 13, out _);
        }

        [TestMethod]
        public void TryParse_Str_MustThrowException()
        {
            Assert.ThrowsException<CodeParseEx>(() => _parser.TryParse("\"hello world\'", 0, out _, out _));
            Assert.ThrowsException<CodeParseEx>(() => _parser.TryParse("\'hello world\"", 0, out _, out _));
        }
    }
}
