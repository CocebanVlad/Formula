using System;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IExprBuilder
    {
        IExpr Build(BuildContext context, IExprBuilder initiator, Func<IExpr> next);
    }
}
