using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tests.Utils
{
    public static class ParserAssert
    {
        public static void IsTrue<TToken>(Parser parser, in string str, int expectedIdxE, out TToken concreteToken) where TToken : Token
        {
            Assert.IsTrue(parser.TryParse(str, 0, out int idxE, out Token token));
            Assert.AreEqual(expectedIdxE, idxE);
            Assert.IsInstanceOfType(token, typeof(TToken));
            concreteToken = (TToken)token;
        }
    }
}
