using System.Collections.Generic;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IBuildingPipeline
    {
        IList<IExpr> Build(IList<IToken> tokens);
    }
}
