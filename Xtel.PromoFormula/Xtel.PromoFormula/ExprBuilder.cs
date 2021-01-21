using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class ExprBuilder : IExprBuilder
    {
        public abstract IExpr Build(BuildContext context, IExprBuilder initiator, Func<IExpr> next);
    }
}
