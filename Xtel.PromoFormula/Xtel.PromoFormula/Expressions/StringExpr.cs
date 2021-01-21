using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class StringExpr : ConstantExpr
    {
        public new StringToken Token => (StringToken)base.Token;

        public StringExpr(StringToken token)
        {
            base.Token = token;
        }
    }
}
