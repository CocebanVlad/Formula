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
        public override Enums.Type ReturnType => Token.ConstValueType;

        protected ConstantExpr(IEnv env)
            : base(env)
        {
        }

        public override object Eval() => Token.ConstValue;

        public override string GetAsString() => Token.ConstValueAsString;

        public override string ToString() => Token.ToString();
    }

    public static class ConstantExprFactory
    {
        public static ConstantExpr Create(IConstantToken token, IEnv env)
        {
            if (token is BoolToken b)
            {
                return new BoolExpr(b, env);
            }

            if (token is NumberToken num)
            {
                return new NumberExpr(num, env);
            }

            if (token is StringToken str)
            {
                return new StringExpr(str, env);
            }

            throw new BuildEx(token.IdxS, token.IdxE,
                string.Format(tr.unknown_constant_token__0, token.GetType().FullName));
        }
    }
}
