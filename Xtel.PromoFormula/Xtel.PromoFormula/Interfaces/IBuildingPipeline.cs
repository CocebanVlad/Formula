using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IBuildingPipeline
    {
        IList<IExpr> Build(IList<IToken> tokens);
    }
}
