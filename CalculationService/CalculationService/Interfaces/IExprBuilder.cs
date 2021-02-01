using System;

namespace CalculationService.Interfaces
{
    public interface IExprBuilder
    {
        IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next);
    }
}
