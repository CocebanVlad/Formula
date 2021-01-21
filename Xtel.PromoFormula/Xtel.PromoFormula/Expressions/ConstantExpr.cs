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
        public override string ReturnType => Token.ConstValueType;

        public override object Eval(IEvalEnv env) => Token.ConstValue;

        public override string ToString() => Token.ToString();
    }
}
