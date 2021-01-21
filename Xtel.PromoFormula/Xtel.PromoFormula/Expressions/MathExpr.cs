using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class MathExpr : Expr, ICanBePrefixedWithPlus, ICanBePrefixedWithMinus
    {
        public ArithmeticSymbolToken Token { get; set; }
        public IExpr A { get; set; }
        public IExpr B { get; set; }

        public override int IdxS => A.IdxS;
        public override int IdxE => B.IdxE;
        public override string ReturnType => Constants.NUMBER_TYPE;

        public override object Eval(IEvalEnv env)
        {
            if (!(A.Eval(env) is double a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE, $"Is not a number: {A.GetType()}");
            }

            if (!(B.Eval(env) is double b))
            {
                throw new RuntimeEx(B.IdxS, B.IdxE, $"Is not a number: {A.GetType()}");
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

            throw new RuntimeEx(Token.IdxS, Token.IdxE,
                $"Unknown operation: ArithmeticOperation.{Token.Operation}");
        }

        public object ApplyPlus(IEvalEnv env) => +(double)Eval(env);

        public object ApplyMinus(IEvalEnv env) => -(double)Eval(env);

        public override string ToString() => $"{A} {Token} {B}";
    }
}
