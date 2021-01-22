using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class PlusOrMinusExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ArithmeticSymbolToken t
                && (t.Operation == ArithmeticOperation.Add || t.Operation == ArithmeticOperation.Subtract))
            {
                ctx.MoveToTheNextIndex();

                var nextExpr = next();
                ThrowIfExprIsNull(nextExpr, t);

                if (nextExpr is ICanBePrefixedWithPlusOrMinus expr)
                {
                    return new PlusOrMinusExpr(t.Operation == ArithmeticOperation.Add)
                    {
                        Expr = expr,
                    };
                }
            }

            return null;
        }
    }
}
