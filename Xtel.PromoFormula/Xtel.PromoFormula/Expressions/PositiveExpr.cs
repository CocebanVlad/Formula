using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Expressions
{
    public class PositiveExpr : Expr, ICanBePrefixedWithMinus
    {
        public ICanBePrefixedWithPlus Expr { get; set; }

        public override int IdxS => Expr.IdxS;
        public override int IdxE => Expr.IdxE;
        public override string ReturnType => Expr.ReturnType;

        public override object Eval(IEvalEnv env) => Expr.ApplyPlus(env);

        public object ApplyMinus(IEvalEnv env) => -(double)Eval(env);

        public override string ToString() => "+" + Expr.ToString();
    }
}
