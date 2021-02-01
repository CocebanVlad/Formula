using System.Collections.Generic;

namespace CalculationService.Interfaces
{
    public interface IBuildingPipeline
    {
        IList<IExpr> Build(IList<IToken> tokens);
    }
}
