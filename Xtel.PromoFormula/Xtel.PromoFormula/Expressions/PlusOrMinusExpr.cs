using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Expressions
{
    public class PlusOrMinusExpr : Expr, ICanBePrefixedWithPlusOrMinus
    {
        public ICanBePrefixedWithPlusOrMinus Expr { get; set; }
        public bool IsPlus { get; set; }
        public bool IsMinus => !IsPlus;

        public override int IdxS => Expr.IdxS;
        public override int IdxE => Expr.IdxE;
        public override string ReturnType => Expr.ReturnType;

        public PlusOrMinusExpr(bool isPlus)
        {
            IsPlus = isPlus;
        }

        public object ApplyPlus(IEvalEnv env) => IsPlus ? Expr.Eval(env) : Expr.ApplyPlus(env);

        public object ApplyMinus(IEvalEnv env) => Expr.ApplyMinus(env);

        public override object Eval(IEvalEnv env) => IsPlus ? ApplyPlus(env) : ApplyMinus(env);

        public override string ToString() => (IsPlus ? "+" : "-") + Expr.ToString();
    }
}
