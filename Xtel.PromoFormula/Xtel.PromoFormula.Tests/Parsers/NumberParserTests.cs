﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Parsers;
using Xtel.PromoFormula.Tests.Utils;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Tests.Parsers
{
    [TestClass]
    public class NumberParserTests
    {
        private readonly Parser _parser;

        public NumberParserTests()
        {
            _parser = new NumberParser();
        }

        [TestMethod]
        public void TryParse_Number_MustReturnTrue()
        {
            NumberToken token;

            ParserAssert.IsTrue(_parser, "1234", 4, out token);
            Assert.AreEqual(1234, token.Number);

            ParserAssert.IsTrue(_parser, "1e-7", 4, out token);
            Assert.AreEqual(1e-7, token.Number);

            ParserAssert.IsTrue(_parser, "5.09", 4, out token);
            Assert.AreEqual(5.09, token.Number);

            ParserAssert.IsTrue(_parser, "1.33", 4, out token);
            Assert.AreEqual(1.33, token.Number);

            ParserAssert.IsTrue(_parser, "1e10", 4, out token);
            Assert.AreEqual(1e10, token.Number);

            ParserAssert.IsTrue(_parser, "1e+3", 4, out token);
            Assert.AreEqual(1e+3, token.Number);

            ParserAssert.IsTrue(_parser, "1_23", 4, out token);
            Assert.AreEqual(1_23, token.Number);
        }

        [TestMethod]
        public void TryParse_InvalidNumericLiteral_MustThrowException()
        {
            Assert.ThrowsException<ParsingException>(() => _parser.TryParse("1e2.4", 0, out _, out _));
            Assert.ThrowsException<ParsingException>(() => _parser.TryParse("1234e", 0, out _, out _));
        }
    }
}
