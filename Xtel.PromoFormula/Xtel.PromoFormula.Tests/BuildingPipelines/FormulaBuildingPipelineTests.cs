using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xtel.PromoFormula.BuildingPipelines;
using Xtel.PromoFormula.Environments;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Functions;
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

            var env =
                new FormulaEnv();
            env.DiscoverFuncsFromAssembly(typeof(Sys).Assembly);

            _pipeline = new FormulaBuildingPipeline(env);
        }

        [TestMethod]
        public void Build_MathExpr_MustReturnExpectedEvalValue()
        {
            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "((1 + (1 + 1) * 10))", 21);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "((1) + (1 + 1)) * 10", 30);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "(((1 + 1 + 1 * 10)))", 12);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "((6 / (2 % 4) * 10))", 30);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "108.9e7 + 1 * 10 / 2", 1089000005);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "1.3 * 1.3 * 1.3 * 12", 26.364000000000004);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "+-+-+-+-+-+1", -1);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "+-+-+-+-+--1", 1);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "-1 + -1", -2);

            EvalAssert.IsExpectedEvalResult<double>(
                _tokenizer, _pipeline, "-(1 + 1)", -2);
        }

        [TestMethod]
        public void Build_MathExpr_MustThrowException()
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
                _pipeline.Build(_tokenizer.Tokenize("(1) - 1)")));
        }

        [TestMethod]
        public void Build_ConditionalExpr_WithBools_MustReturnExpectedEvalValue()
        {
            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "true === true", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "true !== true", false);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "true !== false", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "true !== !false", false);
        }

        [TestMethod]
        public void Build_ConditionalExpr_WithNumbers_MustReturnExpectedEvalValue()
        {
            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "10 == 10", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "10 != 10", false);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "10 != 9", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "10 >= 10", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "10 >= 9", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "10 >= 11", false);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "10 <= 11", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "11 <= 11", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "-11 <= 11", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "20 <= 11", false);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "(10 * 2) === (9 + 9 + 2)", true);
        }

        [TestMethod]
        public void Build_ConditionalExpr_WithStrings_MustReturnExpectedEvalValue()
        {
            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "\"hello\" === 'hello'", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "\"hello\" == 'world'", false);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "\"hello\" != 'world'", true);
        }

        [TestMethod]
        public void Build_LogicalExpr_MustReturnExpectedEvalValue()
        {
            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "true && true", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "true && false", false);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "true || false", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "(1 + 1 * 2 == 4 + 1) || ((4 / 2) % 2 == 0)", true);

            EvalAssert.IsExpectedEvalResult<bool>(
                _tokenizer, _pipeline, "1 + 1 + 1 == 4 || 1 + 2 == 3", true);
        }

        [TestMethod]
        public void Build_StringConcatExpr_MustReturnExpectedEvalValue()
        {
            EvalAssert.IsExpectedEvalResult<string>(
                _tokenizer, _pipeline, "'a' + 's' + 'd'", "asd");

            EvalAssert.IsExpectedEvalResult<string>(
                _tokenizer, _pipeline, "((6 / (2 % 4) * 10)) + ' cm'", "30 cm");
        }

        [TestMethod]
        public void Build_StringConcatExpr_MustThrowException()
        {
            Assert.ThrowsException<BuildEx>(() =>
                _pipeline.Build(_tokenizer.Tokenize("'a' + 's' * 'd'")));

            Assert.ThrowsException<BuildEx>(() =>
                _pipeline.Build(_tokenizer.Tokenize("((6 / (2 % 4) * 10)) - ' cm'")));
        }

        [TestMethod]
        public void Build_FuncExpr_MustReturnExpectedEvalValue()
        {
            EvalAssert.IsExpectedEvalResult<double>(_tokenizer, _pipeline,
                "Sum([1, 2, 3, 4, 5])", 15);

            EvalAssert.IsExpectedEvalResult<string>(_tokenizer, _pipeline,
                "Iif((10 % 5) == 0, 'Yeey', -1)", "Yeey");
        }
    }
}
