using System;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IExprBuilder
    {
        IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next);
    }
}
