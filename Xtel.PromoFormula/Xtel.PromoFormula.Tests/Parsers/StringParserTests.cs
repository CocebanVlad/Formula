using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Parsers;
using Xtel.PromoFormula.Tests.Utils;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Tests.Parsers
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
            Assert.ThrowsException<ParseEx>(() => _parser.TryParse("\"hello world\'", 0, out _, out _));
            Assert.ThrowsException<ParseEx>(() => _parser.TryParse("\'hello world\"", 0, out _, out _));
        }
    }
}
