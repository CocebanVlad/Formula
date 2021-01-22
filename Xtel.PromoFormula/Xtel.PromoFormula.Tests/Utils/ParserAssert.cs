using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tests.Utils
{
    public static class ParserAssert
    {
        public static void IsTrue<TToken>(
            IParser parser,
            in string str,
            int expectedIdxE,
            out TToken concreteToken) where TToken : IToken
        {
            Assert.IsTrue(parser.TryParse(str, 0, out int idxE, out IToken token));
            Assert.AreEqual(expectedIdxE, idxE);
            Assert.IsInstanceOfType(token, typeof(TToken));
            concreteToken = (TToken)token;
        }
    }
}
