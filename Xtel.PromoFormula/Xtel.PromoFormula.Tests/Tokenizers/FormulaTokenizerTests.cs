using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Tests.Utils;
using Xtel.PromoFormula.Tokenizers;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Tests.Tokenizers
{
    [TestClass]
    public class FormulaTokenizerTests
    {
        private readonly Tokenizer _tokenizer;

        public FormulaTokenizerTests()
        {
            _tokenizer = new FormulaTokenizer();
        }

        [TestMethod]
        public void Tokenize_Formula_01_MustReturnExpectedTokens()
        {
            var formula = "SOURCE(\"NETTURNOVER\") * (SOURCE(\"DEF_DISC_PERC\") / 100)";
            var tokens = _tokenizer.Tokenize(formula).ToList();
            Assert.AreEqual(13, tokens.Count);

            TokenizerAssert.AssertToken<LiteralToken>(tokens[0], (token) =>
            {
                Assert.AreEqual("SOURCE", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[1], (token) =>
            {
                Assert.IsTrue(token.IsOpen);
            });
            TokenizerAssert.AssertToken<StringToken>(tokens[2], (token) =>
            {
                Assert.AreEqual("NETTURNOVER", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[3], (token) =>
            {
                Assert.IsFalse(token.IsOpen);
            });
            TokenizerAssert.AssertToken<ArithmeticSymbolToken>(tokens[4], (token) =>
            {
                Assert.AreEqual(ArithmeticOperation.Multiply, token.Operation);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[5], (token) =>
            {
                Assert.IsTrue(token.IsOpen);
            });
            TokenizerAssert.AssertToken<LiteralToken>(tokens[6], (token) =>
            {
                Assert.AreEqual("SOURCE", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[7], (token) =>
            {
                Assert.IsTrue(token.IsOpen);
            });
            TokenizerAssert.AssertToken<StringToken>(tokens[8], (token) =>
            {
                Assert.AreEqual(token.String, "DEF_DISC_PERC");
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[9], (token) =>
            {
                Assert.IsFalse(token.IsOpen);
            });
            TokenizerAssert.AssertToken<ArithmeticSymbolToken>(tokens[10], (token) =>
            {
                Assert.AreEqual(ArithmeticOperation.Divide, token.Operation);
            });
            TokenizerAssert.AssertToken<NumberToken>(tokens[11], (token) =>
            {
                Assert.AreEqual(token.Number, 100);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[12], (token) =>
            {
                Assert.IsFalse(token.IsOpen);
            });
        }

        [TestMethod]
        public void Tokenize_Formula_02_MustReturnExpectedTokens()
        {
            var formula = "SOURCE(\"VOL_ACTUALS_SELL_IN_MAN\") * "
                + "IIF(SOURCE(\"WEIGHT_UOM_RES\") == 1, 1, 0) + CONV_FACT(\"EP\", \"SC\") * SOURCE(\"VOL_ACTUALS_SELL_IN_MAN\")";
            var tokens = _tokenizer.Tokenize(formula).ToList();
            Assert.AreEqual(30, tokens.Count);

            TokenizerAssert.AssertToken<LiteralToken>(tokens[0], (token) =>
            {
                Assert.AreEqual("SOURCE", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[1], (token) =>
            {
                Assert.IsTrue(token.IsOpen);
            });
            TokenizerAssert.AssertToken<StringToken>(tokens[2], (token) =>
            {
                Assert.AreEqual("VOL_ACTUALS_SELL_IN_MAN", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[3], (token) =>
            {
                Assert.IsFalse(token.IsOpen);
            });
            TokenizerAssert.AssertToken<ArithmeticSymbolToken>(tokens[4], (token) =>
            {
                Assert.AreEqual(ArithmeticOperation.Multiply, token.Operation);
            });
            TokenizerAssert.AssertToken<LiteralToken>(tokens[5], (token) =>
            {
                Assert.AreEqual("IIF", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[6], (token) =>
            {
                Assert.IsTrue(token.IsOpen);
            });
            TokenizerAssert.AssertToken<LiteralToken>(tokens[7], (token) =>
            {
                Assert.AreEqual("SOURCE", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[8], (token) =>
            {
                Assert.IsTrue(token.IsOpen);
            });
            TokenizerAssert.AssertToken<StringToken>(tokens[9], (token) =>
            {
                Assert.AreEqual("WEIGHT_UOM_RES", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[10], (token) =>
            {
                Assert.IsFalse(token.IsOpen);
            });
            TokenizerAssert.AssertToken<ComparisonToken>(tokens[11], (token) =>
            {
                Assert.AreEqual(ComparisonOperator.Equal, token.Operator);
            });
            TokenizerAssert.AssertToken<NumberToken>(tokens[12], (token) =>
            {
                Assert.AreEqual(1, token.Number);
            });
            TokenizerAssert.AssertToken<SeparatorToken>(tokens[13], (token) =>
            {
            });
            TokenizerAssert.AssertToken<NumberToken>(tokens[14], (token) =>
            {
                Assert.AreEqual(1, token.Number);
            });
            TokenizerAssert.AssertToken<SeparatorToken>(tokens[15], (token) =>
            {
            });
            TokenizerAssert.AssertToken<NumberToken>(tokens[16], (token) =>
            {
                Assert.AreEqual(0, token.Number);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[17], (token) =>
            {
                Assert.IsFalse(token.IsOpen);
            });
            TokenizerAssert.AssertToken<ArithmeticSymbolToken>(tokens[18], (token) =>
            {
                Assert.AreEqual(ArithmeticOperation.Add, token.Operation);
            });
            TokenizerAssert.AssertToken<LiteralToken>(tokens[19], (token) =>
            {
                Assert.AreEqual("CONV_FACT", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[20], (token) =>
            {
                Assert.IsTrue(token.IsOpen);
            });
            TokenizerAssert.AssertToken<StringToken>(tokens[21], (token) =>
            {
                Assert.AreEqual("EP", token.String);
            });
            TokenizerAssert.AssertToken<SeparatorToken>(tokens[22], (token) =>
            {
            });
            TokenizerAssert.AssertToken<StringToken>(tokens[23], (token) =>
            {
                Assert.AreEqual("SC", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[24], (token) =>
            {
                Assert.IsFalse(token.IsOpen);
            });
            TokenizerAssert.AssertToken<ArithmeticSymbolToken>(tokens[25], (token) =>
            {
                Assert.AreEqual(ArithmeticOperation.Multiply, token.Operation);
            });
            TokenizerAssert.AssertToken<LiteralToken>(tokens[26], (token) =>
            {
                Assert.AreEqual("SOURCE", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[27], (token) =>
            {
                Assert.IsTrue(token.IsOpen);
            });
            TokenizerAssert.AssertToken<StringToken>(tokens[28], (token) =>
            {
                Assert.AreEqual("VOL_ACTUALS_SELL_IN_MAN", token.String);
            });
            TokenizerAssert.AssertToken<ParenthesisToken>(tokens[29], (token) =>
            {
                Assert.IsFalse(token.IsOpen);
            });
        }
    }
}
