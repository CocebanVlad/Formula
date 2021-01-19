using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Parsers;
using Xtel.PromoFormula.Tests.Utils;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Tests.Parsers
{
    [TestClass]
    public class LiteralParserTests
    {
        private readonly Parser _parser;

        public LiteralParserTests()
        {
            _parser = new LiteralParser();
        }

        [TestMethod]
        public void TryParse_LiteralStartingWithNumber_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("0abc ", 0, out _, out _));
        }

        [TestMethod]
        public void TryParse_LiteralStartingWithChar_MustReturnTrue()
        {
            ParserAssert.IsTrue<LiteralToken>(_parser, "ab_1 asd ", 4, out _);
            ParserAssert.IsTrue<LiteralToken>(_parser, "ab_2-asd ", 4, out _);
            ParserAssert.IsTrue<LiteralToken>(_parser, "ab_3,asd ", 4, out _);
            ParserAssert.IsTrue<LiteralToken>(_parser, "abc4(asd ", 4, out _);
            ParserAssert.IsTrue<LiteralToken>(_parser, "abc0;asd ", 4, out _);
        }

        [TestMethod]
        public void TryParse_LiteralStartingWithUnderscore_MustReturnTrue()
        {
            ParserAssert.IsTrue<LiteralToken>(_parser, "_ab_1 asd ", 5, out _);
            ParserAssert.IsTrue<LiteralToken>(_parser, "_ab_2-asd ", 5, out _);
            ParserAssert.IsTrue<LiteralToken>(_parser, "_ab_3,asd ", 5, out _);
            ParserAssert.IsTrue<LiteralToken>(_parser, "_abc4(asd ", 5, out _);
            ParserAssert.IsTrue<LiteralToken>(_parser, "_abc0;asd ", 5, out _);
        }

        [TestMethod]
        public void TryParse_LiteralStartingWithQuotationMark_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("\"bc ", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("\'bc ", 0, out _, out _));
        }
    }
}
