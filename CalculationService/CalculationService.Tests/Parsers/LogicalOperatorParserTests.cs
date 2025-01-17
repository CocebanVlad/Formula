﻿using CalculationService.Parsers;
using CalculationService.Tests.Utils;
using CalculationService.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationService.Tests.Parsers
{
    [TestClass]
    public class LogicalOperatorParserTests
    {
        private readonly Parser _parser;

        public LogicalOperatorParserTests()
        {
            _parser = new LogicalOperatorParser();
        }

        [TestMethod]
        public void TryParse_And_MustReturnTrue()
        {
            ParserAssert.IsTrue<LogicalOperatorToken>(_parser, "&&  1", 2, out _);
            ParserAssert.IsTrue<LogicalOperatorToken>(_parser, "&&& )", 2, out _);
            ParserAssert.IsTrue<LogicalOperatorToken>(_parser, "&&abc", 2, out _);
        }

        [TestMethod]
        public void TryParse_StrSimilarToAnd_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("&  ", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("&.&", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("& &", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("&-&", 0, out _, out _));
        }

        [TestMethod]
        public void TryParse_Or_MustReturnTrue()
        {
            ParserAssert.IsTrue<LogicalOperatorToken>(_parser, "||  1", 2, out _);
            ParserAssert.IsTrue<LogicalOperatorToken>(_parser, "||| )", 2, out _);
            ParserAssert.IsTrue<LogicalOperatorToken>(_parser, "||abc", 2, out _);
        }

        [TestMethod]
        public void TryParse_StrSimilarToOr_MustReturnFalse()
        {
            Assert.IsFalse(_parser.TryParse("|  ", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("|.|", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("| |", 0, out _, out _));
            Assert.IsFalse(_parser.TryParse("|-|", 0, out _, out _));
        }
    }
}
