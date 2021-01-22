using System;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class ExprBuilder : IExprBuilder
    {
        public abstract IExpr Build(BuildContext context, IExprBuilder initiator, Func<IExpr> next);

        public void ThrowIfExprIsNull(IExpr expr, IToken token)
        {
            if (expr == null)
            {
                throw new BuildEx(token.IdxS, token.IdxE, $"Unexpected token: {token}");
            }
        }
    }
}
