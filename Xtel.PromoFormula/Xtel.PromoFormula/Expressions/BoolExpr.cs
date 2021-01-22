using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class BoolExpr : ConstantExpr, ICanBeNegated
    {
        public new BoolToken Token => (BoolToken)base.Token;

        public BoolExpr(BoolToken token)
        {
            base.Token = token;
        }

        public object Negate(IEvalEnv env) => !(bool)base.Eval(env);
    }
}
