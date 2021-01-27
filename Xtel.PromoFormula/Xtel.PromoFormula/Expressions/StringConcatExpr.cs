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
        public override Enums.Type ReturnType => Enums.Type.String;

        public StringConcatExpr(IEnv env)
            : base(env)
        {
        }

        private string Concat() => A.GetAsString() + B.GetAsString();

        public override object Eval() => Concat();

        public override string GetAsString() => Concat();

        public override string ToString() => $"{A} {Token} {B}";
    }
}
