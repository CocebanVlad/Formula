using CalculationService.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationService.Tests
{
    [TestClass]
    public class CalculationServiceTests
    {
        private readonly CalculationService _service
            = new CalculationService();

        [TestMethod]
        public void Build_MathExpr_MustReturnExpectedEvalValue()
        {
            Assert.AreEqual(21d, _service.Build("((1 + (1 + 1) * 10))").Eval());
            Assert.AreEqual(30d, _service.Build("((1) + (1 + 1)) * 10").Eval());
            Assert.AreEqual(12d, _service.Build("(((1 + 1 + 1 * 10)))").Eval());
            Assert.AreEqual(30d, _service.Build("((6 / (2 % 4) * 10))").Eval());
            Assert.AreEqual(1089000005d, _service.Build("108.9e7 + 1 * 10 / 2").Eval());
            Assert.AreEqual(26.364000000000004d, _service.Build("1.3 * 1.3 * 1.3 * 12").Eval());
            Assert.AreEqual(-1d, _service.Build("+-+-+-+-+-+1").Eval());
            Assert.AreEqual(1d, _service.Build("+-+-+-+-+--1").Eval());
            Assert.AreEqual(-2d, _service.Build("-1 + -1").Eval());
            Assert.AreEqual(-2d, _service.Build("-(1 + 1)").Eval());
            Assert.AreEqual(-2d, _service.Build("-AsAny(2)").Eval());
            Assert.AreEqual(2d, _service.Build("-AsAny(-2)").Eval());
            Assert.AreEqual(-1d, _service.Build("-(1)").Eval());
            Assert.AreEqual(-2d, _service.Build("-(AsAny(1 + 1))").Eval());
            Assert.AreEqual(-2d, _service.Build("-AsAny(1 + 1)").Eval());
        }

        [TestMethod]
        public void Build_MathExpr_MustThrowException()
        {
            Assert.ThrowsException<CodeBuildEx>(() => _service.Build("((1 + (1 + 1) * 10()"));
            Assert.ThrowsException<CodeBuildEx>(() => _service.Build("() + 1"));
            Assert.ThrowsException<CodeBuildEx>(() => _service.Build("1 - (+) - 1"));
            Assert.ThrowsException<CodeBuildEx>(() => _service.Build("((1) + (1)) + 1) * 10"));
            Assert.ThrowsException<RuntimeEx>(() => _service.Build("-AsAny('2')").Eval());
            Assert.ThrowsException<RuntimeEx>(() => _service.Build("-AsAny(1 + '2')").Eval());
        }

        [TestMethod]
        public void Build_ConditionalExpr_WithBools_MustReturnExpectedEvalValue()
        {
            Assert.AreEqual(true, _service.Build("true === true").Eval());
            Assert.AreEqual(false, _service.Build("true !== true").Eval());
            Assert.AreEqual(true, _service.Build("true !== false").Eval());
            Assert.AreEqual(false, _service.Build("true !== !false").Eval());
        }

        [TestMethod]
        public void Build_ConditionalExpr_WithNumbers_MustReturnExpectedEvalValue()
        {
            Assert.AreEqual(true, _service.Build("10 == 10").Eval());
            Assert.AreEqual(false, _service.Build("10 != 10").Eval());
            Assert.AreEqual(true, _service.Build("10 != 9").Eval());
            Assert.AreEqual(true, _service.Build("10 >= 10").Eval());
            Assert.AreEqual(true, _service.Build("10 >= 9").Eval());
            Assert.AreEqual(false, _service.Build("(((10)) >= (11))").Eval());
            Assert.AreEqual(true, _service.Build("10 <= 11").Eval());
            Assert.AreEqual(true, _service.Build("11 <= 11").Eval());
            Assert.AreEqual(true, _service.Build("-11 <= (11)").Eval());
            Assert.AreEqual(false, _service.Build("20 <= 11").Eval());
            Assert.AreEqual(true, _service.Build("(10 * 2) === (9 + 9 + 2)").Eval());
            Assert.AreEqual(true, _service.Build("!AsAny(20 <= 11)").Eval());
        }

        [TestMethod]
        public void Build_ConditionalExpr_WithNumbers_MustThrowException()
        {
            Assert.ThrowsException<RuntimeEx>(() => _service.Build("!AsAny('20 <= 11')").Eval());
        }

        [TestMethod]
        public void Build_ConditionalExpr_WithStrings_MustReturnExpectedEvalValue()
        {
            Assert.AreEqual(true, _service.Build("\"hello\" === 'hello'").Eval());
            Assert.AreEqual(false, _service.Build("\"hello\" == 'world'").Eval());
            Assert.AreEqual(true, _service.Build("\"hello\" != 'world'").Eval());
        }

        [TestMethod]
        public void Build_LogicalExpr_MustReturnExpectedEvalValue()
        {
            Assert.AreEqual(true, _service.Build("true && true").Eval());
            Assert.AreEqual(false, _service.Build("true && false").Eval());
            Assert.AreEqual(true, _service.Build("false || true").Eval());
            Assert.AreEqual(true, _service.Build("true || -AsAny(true) == -1").Eval()); // must pass because of the first expr
            Assert.AreEqual(true, _service.Build("(1 + 1 * 2 == 4 + 1) || ((4 / 2) % 2 == 0)").Eval());
            Assert.AreEqual(true, _service.Build("1 + 1 + 1 == 4 || 1 + 2 == 3").Eval());
            Assert.AreEqual(true, _service.Build("AsAny(1 + 1 + 1) == 4 || 1 + 2 == AsAny(3) && AsAny('1') == AsAny('1')").Eval());
        }

        [TestMethod]
        public void Build_LogicalExpr_MustThrowException()
        {
            Assert.ThrowsException<RuntimeEx>(() =>
                _service.Build("AsAny(1 + 1 + 1) == 4 || 1 + 2 == AsAny(3) && 1 == AsAny('1')").Eval());
        }

        [TestMethod]
        public void Build_StringConcatExpr_MustReturnExpectedEvalValue()
        {
            Assert.AreEqual("asd", _service.Build("'a' + 's' + 'd'").Eval());
            Assert.AreEqual("30 cm", _service.Build("((6 / (AsAny(2 % 4)) * 10)) + AsAny(' cm')").Eval());
            Assert.AreEqual("1a", _service.Build("1 + AsAny('a')").Eval());
        }

        [TestMethod]
        public void Build_StringConcatExpr_MustThrowException()
        {
            Assert.ThrowsException<CodeBuildEx>(() => _service.Build("'a' + 's' * 'd'"));
            Assert.ThrowsException<CodeBuildEx>(() => _service.Build("((6 / (2 % 4) * 10)) - ' cm'"));
        }

        [TestMethod]
        public void Build_FuncExpr_MustReturnExpectedEvalValue()
        {
            Assert.AreEqual(15d, _service.Build("Sum([1, 2, 3, 4, 5])").Eval());

            //
            // Even if the ELSE statement would have thrown a runtime exception,
            // that should not happen, due to condition.
            Assert.AreEqual("Hello", _service.Build("Iif((10 % 5) == 0, 'Hello', AsAny(-1) == AsAny('a'))").Eval());
            // but not here
            Assert.ThrowsException<RuntimeEx>(() =>
                _service.Build("Iif((10 % 5) != 0, 'Hello', AsAny(-1) == AsAny('a'))").Eval());
        }
    }
}
