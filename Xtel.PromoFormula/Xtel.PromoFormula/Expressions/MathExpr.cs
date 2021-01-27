using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class MathExpr : Expr, IHasAAndB, ICanBeUsedAsNumber, ICanBePrefixedWithPlusOrMinus
    {
        public ArithmeticSymbolToken Token { get; set; }
        public IExpr A { get; set; }
        public IExpr B { get; set; }

        public override int IdxS => A.IdxS;
        public override int IdxE => B.IdxE;
        public override Enums.Type ReturnType => Enums.Type.Number;

        public MathExpr(IEnv env)
            : base(env)
        {
        }

        private double ExecOp()
        {
            if (!(A.Eval() is double a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.Number));
            }

            if (!(B.Eval() is double b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.Number));
            }

            switch (Token.Operation)
            {
                case ArithmeticOperation.Add:
                    return a + b;
                case ArithmeticOperation.Subtract:
                    return a - b;
                case ArithmeticOperation.Multiply:
                    return a * b;
                case ArithmeticOperation.Divide:
                    return a / b;
                case ArithmeticOperation.Mod:
                    return a % b;
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.unknown_operation__0, Token));
        }

        public double GetAsNumber() => ExecOp();

        public object ApplyPlus() => +ExecOp();

        public object ApplyMinus() => -ExecOp();

        public override object Eval() => ExecOp();

        public override string GetAsString() => Helpers.ToString(Eval());

        public override string ToString() => $"{A} {Token} {B}";
    }
}
