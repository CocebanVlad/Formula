using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class PlusOrMinusExpr : Expr, ICanBePrefixedWithPlusOrMinus
    {
        public ArithmeticSymbolToken Token { get; set; }
        public ICanBePrefixedWithPlusOrMinus Expr { get; set; }
        public bool IsPlus => Token.Operation == ArithmeticOperation.Add;
        public bool IsMinus => !IsPlus;

        public override int IdxS => Expr.IdxS;
        public override int IdxE => Expr.IdxE;
        public override string ReturnType => Expr.ReturnType;

        public object ApplyPlus(IEvalEnv env) => IsPlus ? Expr.Eval(env) : Expr.ApplyPlus(env);

        public object ApplyMinus(IEvalEnv env) => Expr.ApplyMinus(env);

        public override object Eval(IEvalEnv env) => IsPlus ? ApplyPlus(env) : ApplyMinus(env);

        public override string GetAsString(IEvalEnv env) => Helpers.ToString(Eval(env));

        public override string ToString() => $"{Token}{Expr}";
    }
}
