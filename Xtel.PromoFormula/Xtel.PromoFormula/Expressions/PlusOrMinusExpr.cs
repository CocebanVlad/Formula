using CalculationService.Enums;
using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Expressions
{
    public class PlusOrMinusExpr : Expr, ICanBePrefixedWithPlusOrMinus
    {
        public ArithmeticSymbolToken Token { get; set; }
        public ICanBePrefixedWithPlusOrMinus Expr { get; set; }
        public bool IsPlus => Token.Operation == ArithmeticOperation.Add;
        public bool IsMinus => !IsPlus;

        public override int IdxS => Expr.IdxS;
        public override int IdxE => Expr.IdxE;
        public override Enums.Type ReturnType => Expr.ReturnType;

        public PlusOrMinusExpr(IEnv env)
            : base(env)
        {
        }

        public object ApplyPlus() => IsPlus ? Expr.Eval() : Expr.ApplyPlus();

        public object ApplyMinus() => Expr.ApplyMinus();

        public override object Eval() => IsPlus ? ApplyPlus() : ApplyMinus();

        public override string GetAsString() => Helpers.ToString(Eval());

        public override string ToString() => $"{Token}{Expr}";
    }
}
