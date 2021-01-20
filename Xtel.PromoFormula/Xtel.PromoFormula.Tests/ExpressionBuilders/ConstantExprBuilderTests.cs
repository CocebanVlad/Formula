using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.ExpressionBuilders;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tests.Utils;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Tests.ExpressionBuilders
{
    [TestClass]
    public class ConstantExprBuilderTests
    {
        private IExprBuilder _builder;

        public ConstantExprBuilderTests()
        {
            _builder = new ConstantExprBuilder();
        }

        [TestMethod]
        public void TryBuild_Expr_01_MustReturnExpectedExpr()
        {
            var num = 1;
            var tokens = new List<IToken>() { new NumberToken() { Number = num } };
            var ops = new List<IExpr>();

            ConstantExpr expr;

            ExprBuilderAssert.IsTrue(_builder, tokens, ops, 1, out expr);
            Assert.AreEqual(num, (double)expr.Eval(null));
        }

        [TestMethod]
        public void TryBuild_Expr_02_MustReturnExpectedExpr()
        {
            var str = "hello";
            var tokens = new List<IToken>() { new StringToken() { String = str } };
            var ops = new List<IExpr>();

            ConstantExpr expr;

            ExprBuilderAssert.IsTrue(_builder, tokens, ops, 1, out expr);
            Assert.AreEqual(str, (string)expr.Eval(null));
        }

        [TestMethod]
        public void TryBuild_Expr_03_MustReturnExpectedExpr()
        {
            var val = true;
            var tokens = new List<IToken>() { new BoolToken() { Value = val } };
            var ops = new List<IExpr>();

            ConstantExpr expr;

            ExprBuilderAssert.IsTrue(_builder, tokens, ops, 1, out expr);
            Assert.AreEqual(val, (bool)expr.Eval(null));
        }
    }
}
