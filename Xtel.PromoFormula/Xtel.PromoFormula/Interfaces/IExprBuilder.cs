using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IExprBuilder
    {
        IExpr Build(BuildContext context, Func<IExpr> next);
    }
}
