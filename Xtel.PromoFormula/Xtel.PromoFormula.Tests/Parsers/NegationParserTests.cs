using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xtel.PromoFormula.Parsers;
using Xtel.PromoFormula.Tests.Utils;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Tests.Parsers
{
    [TestClass]
    public class NegationParserTests
    {
        private readonly Parser _parser;

        public NegationParserTests()
        {
            _parser = new NegationParser();
        }

        [TestMethod]
        public void TryParse_ExclamationMark_MustReturnTrue()
        {
            ParserAssert.IsTrue<NegationToken>(_parser, "!(true)", 1, out _);
        }
    }
}
