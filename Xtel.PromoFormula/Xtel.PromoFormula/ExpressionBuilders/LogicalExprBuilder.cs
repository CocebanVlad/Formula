using System;
using System.Linq;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class LogicalExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is LogicalOperatorToken t)
            {
                if (initiator is LogicalExprBuilder || ctx.BuiltExpressions.Count == 0)
                {
                    return null;
                }

                var prevExpr =
                    ctx.BuiltExpressions.Last();
                if (prevExpr.ReturnType != Constants.BoolType)
                {
                    throw new BuildEx(t.IdxS, t.IdxE,
                        string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1,
                            t,
                            prevExpr.ReturnType
                            ));
                }

                ctx.MoveToTheNextIndex();

                IExpr nextExpr;
                while (true)
                {
                    nextExpr = next();
                    ThrowIfExprIsNull(nextExpr, t);

                    if (nextExpr.ReturnType == Constants.BoolType)
                    {
                        break;
                    }

                    ctx.BuiltExpressions.Add(nextExpr);
                }

                ctx.BuiltExpressions
                    .RemoveAt(ctx.BuiltExpressions.Count - 1);

                return new LogicalExpr() { Token = t, A = prevExpr, B = nextExpr, };
            }

            return null;
        }
    }
}
