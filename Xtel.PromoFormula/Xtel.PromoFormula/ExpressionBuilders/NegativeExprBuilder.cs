using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class NegativeExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ArithmeticSymbolToken t && t.Operation == ArithmeticOperation.Subtract)
            {
                ctx.MoveToTheNextIndex();

                var nextExpr = next();
                if (nextExpr == null)
                {
                    throw new BuildEx(t.IdxS, t.IdxE, $"Unexpected token: {t}");
                }

                if (nextExpr is ICanBePrefixedWithMinus expr)
                {
                    return new NegativeExpr() { Expr = expr };
                }
            }

            return null;
        }
    }
}
