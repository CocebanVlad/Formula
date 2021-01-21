using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class NumberExpr : ConstantExpr, ICanBePrefixedWithPlus, ICanBePrefixedWithMinus
    {
        public new NumberToken Token => (NumberToken)base.Token;

        public NumberExpr(NumberToken token)
        {
            base.Token = token;
        }

        public object ApplyPlus(IEvalEnv env) => +(double)Eval(env);

        public object ApplyMinus(IEvalEnv env) => -(double)Eval(env);
    }
}
