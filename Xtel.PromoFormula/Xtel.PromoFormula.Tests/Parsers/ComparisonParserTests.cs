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
    public class ComparisonParserTests
    {
        private readonly Parser _parser;

        public ComparisonParserTests()
        {
            _parser = new ComparisonParser();
        }

        [TestMethod]
        public void TryParse_Equal_MustReturnTrue()
        {
            ParserAssert.IsTrue<ComparisonToken>(_parser, "=== ", 3, out _);
            ParserAssert.IsTrue<ComparisonToken>(_parser, "==  ", 2, out _);
            ParserAssert.IsTrue<ComparisonToken>(_parser, "====", 3, out _);
        }

        [TestMethod]
        public void TryParse_NotEqual_MustReturnTrue()
        {
            ParserAssert.IsTrue<ComparisonToken>(_parser, "!== ", 3, out _);
            ParserAssert.IsTrue<ComparisonToken>(_parser, "!=  ", 2, out _);
            ParserAssert.IsTrue<ComparisonToken>(_parser, "!===", 3, out _);
        }

        [TestMethod]
        public void TryParse_GreaterThanOrEqual_MustReturnTrue()
        {
            ParserAssert.IsTrue<ComparisonToken>(_parser, ">= ", 2, out _);
            ParserAssert.IsTrue<ComparisonToken>(_parser, ">==", 2, out _);
        }

        [TestMethod]
        public void TryParse_GreaterThan_MustReturnTrue()
        {
            ParserAssert.IsTrue<ComparisonToken>(_parser, ">  ", 1, out _);
            ParserAssert.IsTrue<ComparisonToken>(_parser, "> =", 1, out _);
        }

        [TestMethod]
        public void TryParse_LessThanOrEqual_MustReturnTrue()
        {
            ParserAssert.IsTrue<ComparisonToken>(_parser, "<= ", 2, out _);
            ParserAssert.IsTrue<ComparisonToken>(_parser, "<==", 2, out _);
        }

        [TestMethod]
        public void TryParse_LessThan_MustReturnTrue()
        {
            ParserAssert.IsTrue<ComparisonToken>(_parser, "<  ", 1, out _);
            ParserAssert.IsTrue<ComparisonToken>(_parser, "< =", 1, out _);
        }
    }
}
