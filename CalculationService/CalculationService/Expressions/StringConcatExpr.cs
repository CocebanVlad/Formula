using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Expressions
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

        private string Concat() => Helpers.Concat(this);

        public override object Eval() => Concat();

        public override string GetAsString() => Concat();

        public override string ToString() => $"{A} {Token} {B}";
    }
}
