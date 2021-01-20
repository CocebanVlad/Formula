using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IExpr
    {
        int IdxS { get; }
        int IdxE { get; }

        object Eval(IEvalEnv env);
    }
}
