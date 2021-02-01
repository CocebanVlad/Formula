using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.Expressions
{
    public class BoolExpr : ConstantExpr, ICanBeUsedAsBool, ICanBeNegated
    {
        public new BoolToken Token => (BoolToken)base.Token;

        public BoolExpr(BoolToken token, IEnv env)
            : base(env)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            base.Token = token;
        }

        public bool GetAsBool() => (bool)base.Eval();

        public object Negate() => Helpers.Negate(this);
    }
}
