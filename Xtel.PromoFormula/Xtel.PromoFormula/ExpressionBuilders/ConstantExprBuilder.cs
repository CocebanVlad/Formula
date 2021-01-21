using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class ConstantExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is IConstantToken token)
            {
                ctx.MoveToTheNextIndex();

                return ConstantExprFactory.Create(token);
            }

            return null;
        }
    }
}
