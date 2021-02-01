using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.Expressions
{
    public class StringExpr : ConstantExpr
    {
        public new StringToken Token => (StringToken)base.Token;

        public StringExpr(StringToken token, IEnv env)
            : base(env)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            base.Token = token;
        }
    }
}
