using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class ExprBuilder : IExprBuilder
    {
        public abstract bool TryBuild(IList<IToken> tokens, int idxS, out int idxE, IList<IExpr> ops, out IExpr expr);
    }
}
