using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xtel.PromoFormula.BuildingPipelines;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tests.Utils;
using Xtel.PromoFormula.Tokenizers;

namespace Xtel.PromoFormula.Tests.BuildingPipelines
{
    [TestClass]
    public class FormulaBuildingPipelineTests
    {
        private readonly ITokenizer _tokenizer;
        private readonly IBuildingPipeline _pipeline;

        public FormulaBuildingPipelineTests()
        {
            _tokenizer = new FormulaTokenizer();
            _pipeline = new FormulaBuildingPipeline();
        }

        [TestMethod]
        public void Build_Expr_01_MustReturnExpectedEvalValue()
        {
            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "((1 + (1 + 1) * 10))", 21);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "((1) + (1 + 1)) * 10", 30);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "(((1 + 1 + 1 * 10)))", 12);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "((6 / (2 % 4) * 10))", 30);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "108.9e7 + 1 * 10 / 2", 1089000005);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "1.3 * 1.3 * 1.3 * 12", 26.364000000000004);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "+-+-+-+-+-+1", -1);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "+-+-+-+-+--1", 1);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, null, "-1 + -1", -2);
        }

        [TestMethod]
        public void Build_Expr_01_MustThrowException()
        {
            Assert.ThrowsException<BuildEx>(() =>
                _pipeline.Build(_tokenizer.Tokenize("((1 + (1 + 1) * 10()")));

            Assert.ThrowsException<BuildEx>(() =>
                _pipeline.Build(_tokenizer.Tokenize("() + 1")));

            Assert.ThrowsException<BuildEx>(() =>
                _pipeline.Build(_tokenizer.Tokenize("1 - (+) - 1")));

            Assert.ThrowsException<BuildEx>(() =>
                _pipeline.Build(_tokenizer.Tokenize("((1) + (1)) + 1) * 10")));

            Assert.ThrowsException<BuildEx>(() =>
                _pipeline.Build(_tokenizer.Tokenize("(1)-1)")));
        }
    }
}
