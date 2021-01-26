using System;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class BoolExpr : ConstantExpr, ICanBeUsedAsBool, ICanBeNegated
    {
        public new BoolToken Token => (BoolToken)base.Token;

        public BoolExpr(BoolToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            base.Token = token;
        }

        public bool GetAsBool(IEvalEnv env) => (bool)base.Eval(env);

        public object Negate(IEvalEnv env) => !(bool)base.Eval(env);
    }
}
