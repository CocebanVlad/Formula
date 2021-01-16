using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class Expr
    {
        public abstract object Eval(EvalEnv env);
    }
}
