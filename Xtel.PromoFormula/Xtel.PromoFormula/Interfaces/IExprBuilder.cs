using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IExprBuilder
    {
        bool TryBuild(IList<IToken> tokens, int idxS, out int idxE, IList<IExpr> ops, out IExpr expr);
    }
}
