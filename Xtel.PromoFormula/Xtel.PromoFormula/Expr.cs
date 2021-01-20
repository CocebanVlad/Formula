using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class Expr
    {
        public abstract int IdxS { get; }
        public abstract int IdxE { get; }

        public abstract object Eval(EvalEnv env);
    }
}
