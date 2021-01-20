using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class TypedExpr<TValue> : Expr where TValue : struct
    {
        public abstract TValue EvalWithAnExpectedType(IEvalEnv env);

        public override object Eval(IEvalEnv env) => EvalWithAnExpectedType(env);
    }
}
