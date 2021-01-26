using System;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class NumberExpr : ConstantExpr, ICanBeUsedAsNumber, ICanBePrefixedWithPlusOrMinus
    {
        public new NumberToken Token => (NumberToken)base.Token;

        public NumberExpr(NumberToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            base.Token = token;
        }

        public double GetAsNumber(IEvalEnv env) => (double)Eval(env);

        public object ApplyPlus(IEvalEnv env) => +(double)Eval(env);

        public object ApplyMinus(IEvalEnv env) => -(double)Eval(env);
    }
}
