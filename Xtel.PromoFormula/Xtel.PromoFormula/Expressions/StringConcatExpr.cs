using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class StringConcatExpr : Expr, IHasAAndB
    {
        public ArithmeticSymbolToken Token { get; set; }
        public IExpr A { get; set; }
        public IExpr B { get; set; }

        public override int IdxS => A.IdxS;
        public override int IdxE => B.IdxE;
        public override string ReturnType => Constants.StringType;

        private string Concat(IEvalEnv env) => A.GetAsString(env) + B.GetAsString(env);

        public override object Eval(IEvalEnv env) => Concat(env);

        public override string GetAsString(IEvalEnv env) => Concat(env);

        public override string ToString() => $"{A} {Token} {B}";
    }
}
