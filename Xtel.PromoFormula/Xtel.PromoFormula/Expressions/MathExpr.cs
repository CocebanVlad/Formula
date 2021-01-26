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
        public override string ReturnType => Constants.NumberType;

        private double ExecuteOperation(IEvalEnv env)
        {
            if (!(A.Eval(env) is double a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Constants.NumberType));
            }

            if (!(B.Eval(env) is double b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Constants.NumberType));
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

        public double GetAsNumber(IEvalEnv env) => ExecuteOperation(env);

        public object ApplyPlus(IEvalEnv env) => +ExecuteOperation(env);

        public object ApplyMinus(IEvalEnv env) => -ExecuteOperation(env);

        public override object Eval(IEvalEnv env) => ExecuteOperation(env);

        public override string GetAsString(IEvalEnv env) => Helpers.ToString(Eval(env));

        public override string ToString() => $"{A} {Token} {B}";
    }
}
