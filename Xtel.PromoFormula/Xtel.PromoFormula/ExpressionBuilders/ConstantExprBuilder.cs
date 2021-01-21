using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class ConstantExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, Func<IExpr> next)
        {
            if (ctx.Token is IConstantToken token)
            {
                ctx.MoveToTheNextIndex();

                return new ConstantExpr()
                {
                    Token = token,
                };
            }

            return null;
        }
    }
}
