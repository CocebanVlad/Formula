using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public abstract class ConstantExpr : Expr
    {
        public IConstantToken Token { get; set; }

        public override int IdxS => Token.IdxS;
        public override int IdxE => Token.IdxE;
        public override string ReturnType => Token.ConstValueType;

        protected ConstantExpr()
        {
        }

        public override object Eval(IEvalEnv env) => Token.ConstValue;

        public override string GetAsString(IEvalEnv env) => Token.ConstValueAsString;

        public override string ToString() => Token.ToString();
    }

    public static class ConstantExprFactory
    {
        public static ConstantExpr Create(IConstantToken t)
        {
            if (t is BoolToken b)
            {
                return new BoolExpr(b);
            }

            if (t is NumberToken n)
            {
                return new NumberExpr(n);
            }

            if (t is StringToken s)
            {
                return new StringExpr(s);
            }

            throw new BuildEx(t.IdxS, t.IdxE,
                string.Format(tr.unknown_constant_token__0, t.GetType().FullName));
        }
    }
}
