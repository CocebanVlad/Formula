using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class ConstantExpr : Expr
    {
        public IConstantToken Token { get; set; }

        public override int IdxS => Token.IdxS;
        public override int IdxE => Token.IdxE;
        public override string ReturnType => Token.ConstValueType;

        protected ConstantExpr()
        {
        }

        public override object Eval(IEvalEnv env) => Token.ConstValue;

        public override string ToString() => Token.ToString();
    }

    public static class ConstantExprFactory
    {
        public static ConstantExpr Create(IConstantToken t)
        {
            if (t is BoolToken)
            {
                return new BoolExpr((BoolToken)t);
            }

            if (t is NumberToken)
            {
                return new NumberExpr((NumberToken)t);
            }

            if (t is StringToken)
            {
                return new StringExpr((StringToken)t);
            }

            throw new BuildEx(t.IdxS, t.IdxE, $"Unknown constant token: {t.GetType()}");
        }
    }
}
