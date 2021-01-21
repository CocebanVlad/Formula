using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Expressions
{
    public class NegativeExpr : Expr, ICanBePrefixedWithPlus
    {
        public ICanBePrefixedWithMinus Expr { get; set; }

        public override int IdxS => Expr.IdxS;
        public override int IdxE => Expr.IdxE;
        public override string ReturnType => Expr.ReturnType;

        public override object Eval(IEvalEnv env) => Expr.ApplyMinus(env);

        public object ApplyPlus(IEvalEnv env) => +(double)Eval(env);

        public override string ToString() => "-" + Expr.ToString();
    }
}
