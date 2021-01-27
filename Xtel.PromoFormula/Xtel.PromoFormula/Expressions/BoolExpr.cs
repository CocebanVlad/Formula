using System;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class BoolExpr : ConstantExpr, ICanBeUsedAsBool, ICanBeNegated
    {
        public new BoolToken Token => (BoolToken)base.Token;

        public BoolExpr(BoolToken token, IEnv env)
            : base(env)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            base.Token = token;
        }

        public bool GetAsBool() => (bool)base.Eval();

        public object Negate() => !(bool)base.Eval();
    }
}
