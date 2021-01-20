using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tests.Utils
{
    public static class ExprBuilderAssert
    {
        public static void IsTrue<TExpr>(
            IExprBuilder builder,
            IList<IToken> tokens,
            IList<IExpr> ops,
            int expectedIdxE,
            out TExpr concreteExpr) where TExpr : IExpr
        {
            Assert.IsTrue(builder.TryBuild(tokens, 0, out int idxE, ops, out IExpr expr));
            Assert.AreEqual(expectedIdxE, idxE);
            Assert.IsInstanceOfType(expr, typeof(TExpr));
            concreteExpr = (TExpr)expr;
        }
    }
}
