using CalculationService.Enums;
using CalculationService.Exceptions;
using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Expressions
{
    public class MathExpr : Expr, IHasAAndB, ICanBeUsedAsNumber, ICanBePrefixedWithPlusOrMinus
    {
        public ArithmeticSymbolToken Token { get; set; }
        public IExpr A { get; set; }
        public IExpr B { get; set; }

        public override int IdxS => A.IdxS;
        public override int IdxE => B.IdxE;
        public override Enums.Type ReturnType =>
            A.ReturnType == Enums.Type.Any || B.ReturnType == Enums.Type.Any ? Enums.Type.Any : Enums.Type.Number; // might also be `String`

        public MathExpr(IEnv env)
            : base(env)
        {
        }

        public double GetAsNumber() => (double)Eval();

        public object ApplyPlus() => Helpers.ApplyPlus(this);

        public object ApplyMinus() => Helpers.ApplyMinus(this);

        public override object Eval()
        {
            var a = A.Eval();
            var b = B.Eval();

            if (a is string || b is string)
            {
                return Helpers.Concat(this);
            }

            if (!(a is double numA))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.Number));
            }

            if (!(b is double numB))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.Number));
            }

            switch (Token.Operation)
            {
                case ArithmeticOperation.Add:
                    return numA + numB;
                case ArithmeticOperation.Subtract:
                    return numA - numB;
                case ArithmeticOperation.Multiply:
                    return numA * numB;
                case ArithmeticOperation.Divide:
                    return numA / numB;
                case ArithmeticOperation.Mod:
                    return numA % numB;
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.unknown_operation__0, Token));
        }

        public override string GetAsString() => Helpers.ToString(Eval());

        public override string ToString() => $"{A} {Token} {B}";
    }
}
