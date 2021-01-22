using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xtel.PromoFormula.Parsers;
using Xtel.PromoFormula.Tests.Utils;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Tests.Parsers
{
    [TestClass]
    public class BoolParserTests
    {
        private readonly Parser _parser;

        public BoolParserTests()
        {
            _parser = new BoolParser();
        }

        [TestMethod]
        public void TryParse_TrueLowercaseWord_MustReturnTrue()
        {
            ParserAssert.IsTrue<BoolToken>(_parser, "true", 4, out _);
        }

        [TestMethod]
        public void TryParse_TrueUppercaseWord_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("TRUE", 0, out _, out _));
        }

        [TestMethod]
        public void TryParse_StrSimilarToTheTrueWord_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("t r u e", 0, out _, out _));
        }

        [TestMethod]
        public void TryParse_FalseLowercaseWord_MustReturnTrue()
        {
            ParserAssert.IsTrue<BoolToken>(_parser, "false", 5, out _);
        }

        [TestMethod]
        public void TryParse_FalseUppercaseWord_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("FALSE", 0, out _, out _));
        }

        [TestMethod]
        public void TryParse_StrSimilarToTheFalseWord_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("f a l s e", 0, out _, out _));
        }
    }
}
