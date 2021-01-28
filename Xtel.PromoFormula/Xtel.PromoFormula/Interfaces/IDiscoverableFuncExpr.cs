using System.Collections.Generic;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IDiscoverableFuncExpr : IExpr, IFunc, IDiscoverableExpr
    {
        IDictionary<IFuncArgsSignature, IList<Enums.Type>> DiscoveredSignatures { get; }
    }
}
