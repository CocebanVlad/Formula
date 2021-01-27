using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class GroupExpr : Expr, ICanBePrefixedWithPlusOrMinus
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

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_apply__0__on__1,
                    "+",
                    InnerExpr.GetType().FullName
                    ));
        }

        public object ApplyMinus()
        {
            if (InnerExpr is ICanBePrefixedWithPlusOrMinus expr)
            {
                return expr.ApplyMinus();
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_apply__0__on__1,
                    "-",
                    InnerExpr.GetType().FullName
                    ));
        }

        public override object Eval() => InnerExpr.Eval();

        public override string GetAsString() => Helpers.ToString(Eval());

        public override string ToString() => $"{OpenToken}{InnerExpr}{CloseToken}";
    }
}
