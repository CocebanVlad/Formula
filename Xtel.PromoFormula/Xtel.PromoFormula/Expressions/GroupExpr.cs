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
        public override string ReturnType => InnerExpr.ReturnType;

        public object ApplyPlus(IEvalEnv env)
        {
            if (InnerExpr is ICanBePrefixedWithPlusOrMinus expr)
            {
                return expr.ApplyPlus(env);
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_apply__0__on__1,
                    "+",
                    InnerExpr.GetType().FullName
                    ));
        }

        public object ApplyMinus(IEvalEnv env)
        {
            if (InnerExpr is ICanBePrefixedWithPlusOrMinus expr)
            {
                return expr.ApplyMinus(env);
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_apply__0__on__1,
                    "-",
                    InnerExpr.GetType().FullName
                    ));
        }

        public override object Eval(IEvalEnv env) => InnerExpr.Eval(env);

        public override string GetAsString(IEvalEnv env) => Helpers.ToString(Eval(env));

        public override string ToString() => $"{OpenToken}{InnerExpr}{CloseToken}";
    }
}
