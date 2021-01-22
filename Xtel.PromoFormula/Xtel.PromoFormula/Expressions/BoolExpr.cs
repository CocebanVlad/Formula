using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class BoolExpr : ConstantExpr
    {
        public new BoolToken Token => (BoolToken)base.Token;

        public BoolExpr(BoolToken token)
        {
            base.Token = token;
        }
    }
}
