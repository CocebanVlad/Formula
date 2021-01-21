using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface ICanBePrefixedWithMinus : IExpr
    {
        object ApplyMinus(IEvalEnv env);
    }
}
