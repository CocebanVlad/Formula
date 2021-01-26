using System;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class StringExpr : ConstantExpr
    {
        public new StringToken Token => (StringToken)base.Token;

        public StringExpr(StringToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            base.Token = token;
        }
    }
}
