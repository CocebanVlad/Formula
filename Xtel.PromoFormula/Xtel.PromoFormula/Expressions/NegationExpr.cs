using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Expressions
{
    public class NegationExpr : Expr, ICanBeNegated
    {
        public ICanBeNegated Expr { get; set; }

        public override int IdxS => Expr.IdxS;
        public override int IdxE => Expr.IdxE;
        public override string ReturnType => Expr.ReturnType;

        public object Negate(IEvalEnv env) => Expr.Eval(env);

        public override object Eval(IEvalEnv env) => Expr.Negate(env);
    }
}
