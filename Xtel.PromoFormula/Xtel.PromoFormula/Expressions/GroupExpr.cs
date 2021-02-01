using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class GroupExpr : Expr, ICanBePrefixedWithPlusOrMinus, ICanBeNegated
    {
        public ParenthesisToken OpenToken { get; set; }
        public ParenthesisToken CloseToken { get; set; }
        public IExpr InnerExpr { get; set; }

        public override int IdxS => OpenToken.IdxS;
        public override int IdxE => CloseToken.IdxE;
        public override Enums.Type ReturnType => InnerExpr.ReturnType;

        public GroupExpr(IEnv env)
            : base(env)
        {
        }

        public object ApplyPlus()
        {
            if (InnerExpr is ICanBePrefixedWithPlusOrMinus expr)
            {
                return expr.ApplyPlus();
            }

            return Helpers.ApplyPlus(this);
        }

        public object ApplyMinus()
        {
            if (InnerExpr is ICanBePrefixedWithPlusOrMinus expr)
            {
                return expr.ApplyMinus();
            }

            return Helpers.ApplyMinus(this);
        }

        public object Negate()
        {
            if (InnerExpr is ICanBeNegated expr)
            {
                return expr.Negate();
            }

            return Helpers.Negate(this);
        }

        public override object Eval() => InnerExpr.Eval();

        public override string GetAsString() => Helpers.ToString(Eval());

        public override string ToString() => $"{OpenToken}{InnerExpr}{CloseToken}";
    }
}
