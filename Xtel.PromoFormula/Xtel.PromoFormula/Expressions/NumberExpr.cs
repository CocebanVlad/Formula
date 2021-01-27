using System;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class NumberExpr : ConstantExpr, ICanBeUsedAsNumber, ICanBePrefixedWithPlusOrMinus
    {
        public new NumberToken Token => (NumberToken)base.Token;

        public NumberExpr(NumberToken token, IEnv env)
            : base(env)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            base.Token = token;
        }

        public double GetAsNumber() => (double)Eval();

        public object ApplyPlus() => +(double)Eval();

        public object ApplyMinus() => -(double)Eval();
    }
}
