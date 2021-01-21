using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface ICanBePrefixedWithPlus : IExpr
    {
        object ApplyPlus(IEvalEnv env);
    }
}
