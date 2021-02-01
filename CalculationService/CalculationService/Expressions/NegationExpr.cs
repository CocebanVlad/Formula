using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Expressions
{
    public class NegationExpr : Expr, ICanBeNegated
    {
        public NegationToken Token { get; set; }
        public ICanBeNegated Expr { get; set; }

        public override int IdxS => Expr.IdxS;
        public override int IdxE => Expr.IdxE;
        public override Enums.Type ReturnType => Expr.ReturnType;

        public NegationExpr(IEnv env)
            : base(env)
        {
        }

        public object Negate() => Expr.Eval();

        public override object Eval() => Expr.Negate();

        public override string GetAsString() => Helpers.ToString(Expr.Eval());

        public override string ToString() => $"{Token}{Expr}";
    }
}
