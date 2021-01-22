using System;
using System.Linq;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class ConditionalExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ComparisonToken t)
            {
                if (initiator is ConditionalExprBuilder)
                {
                    return null;
                }

                if (ctx.BuiltExpressions.Count == 0)
                {
                    return null;
                }

                var prevExpr =
                    ctx.BuiltExpressions.Last();

                ctx.MoveToTheNextIndex();

                var nextExpr = next();
                ThrowIfExprIsNull(nextExpr, t);

                if (prevExpr.ReturnType != nextExpr.ReturnType)
                {
                    throw new BuildEx(t.IdxS, t.IdxE,
                        string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1__and__2,
                            t,
                            prevExpr.ReturnType,
                            nextExpr.ReturnType
                            ));
                }

                ctx.BuiltExpressions
                    .RemoveAt(ctx.BuiltExpressions.Count - 1);

                return new ConditionalExpr() { Token = t, A = prevExpr, B = nextExpr, };
            }

            return null;
        }
    }
}
