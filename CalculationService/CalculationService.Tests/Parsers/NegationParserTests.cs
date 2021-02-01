using CalculationService.Parsers;
using CalculationService.Tests.Utils;
using CalculationService.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationService.Tests.Parsers
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
