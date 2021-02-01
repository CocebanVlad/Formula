using CalculationService.Parsers;
using CalculationService.Tests.Utils;
using CalculationService.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationService.Tests.Parsers
{
    [TestClass]
    public class ArithmeticSymbolParserTests
    {
        private readonly Parser _parser;

        public ArithmeticSymbolParserTests()
        {
            _parser = new ArithmeticSymbolParser();
        }

        [TestMethod]
        public void TryParse_First256Chars_MustReturnTrueOnlyIfCharIsAnArithmeticSymbol()
        {
            for (var c = (char)0; c <= 256; c++) // includes: latin letters, numbers, and symbols
            {
                if ("+-*/%".IndexOf(c) > -1)
                {
                    ParserAssert.IsTrue<ArithmeticSymbolToken>(_parser, c.ToString(), 1, out _);
                }
                else
                {
                    Assert.IsFalse(_parser.TryParse(c.ToString(), 0, out _, out _));
                }
            }
        }
    }
}
