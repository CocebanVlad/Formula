using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class TypedExpr<TValue> : Expr where TValue : struct
    {
        public abstract TValue EvalWithAnExpectedType(EvalEnv env);

        public override object Eval(EvalEnv env) => EvalWithAnExpectedType(env);
    }
}
