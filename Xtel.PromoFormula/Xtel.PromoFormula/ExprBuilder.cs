using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class ExprBuilder
    {
        public abstract bool TryBuild(IList<Token> tokens, int idxS, out int idxE, IList<Expr> exprs, out Expr expr);
    }
}
