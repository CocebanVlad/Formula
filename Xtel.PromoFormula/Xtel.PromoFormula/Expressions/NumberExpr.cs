using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.Expressions
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

        public object ApplyPlus() => Helpers.ApplyPlus(this);

        public object ApplyMinus() => Helpers.ApplyMinus(this);
    }
}
