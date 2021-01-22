using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class GroupExpr : Expr
    {
        public ParenthesisToken OpenToken { get; set; }
        public ParenthesisToken CloseToken { get; set; }
        public IExpr InnerExpr { get; set; }

        public override int IdxS => OpenToken.IdxS;
        public override int IdxE => CloseToken.IdxE;
        public override string ReturnType => InnerExpr.ReturnType;

        public override object Eval(IEvalEnv env) => InnerExpr.Eval(env);

        public override string ToString() => "(" + InnerExpr.ToString() + ")";
    }
}
