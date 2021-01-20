using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class ConstantExprBuilder : ExprBuilder
    {
        public override bool TryBuild(IList<IToken> tokens, int idxS, out int idxE, IList<IExpr> ops, out IExpr expr)
        {
            idxE = idxS;
            expr = null;

            if (tokens[idxS] is IConstantToken token)
            {
                idxE++;
                expr = new ConstantExpr()
                {
                    Token = token,
                };
                ops.Add(expr);

                return true;
            }

            return false;
        }
    }
}
