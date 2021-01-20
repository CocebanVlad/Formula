using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Expressions
{
    public class ConstantExpr : Expr
    {
        public IConstantToken Token { get; set; }

        public override int IdxS => Token.IdxS;
        public override int IdxE => Token.IdxE;

        public override object Eval(IEvalEnv env) => Token.GetValue();
    }
}
