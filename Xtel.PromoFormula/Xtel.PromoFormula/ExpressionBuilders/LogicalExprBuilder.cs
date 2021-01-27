using System;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class LogicalExprBuilder : ExprBuilder
    {
        public LogicalExprBuilder(IEnv env)
            : base(env)
        {
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is LogicalOperatorToken t)
            {
                if (initiator is LogicalExprBuilder || ctx.BuiltExprs.Count == 0)
                {
                    return null;
                }

                var prevExpr = ctx.LastExpr;
                if (prevExpr.ReturnType != Enums.Type.Bool)
                {
                    throw new BuildEx(t.IdxS, t.IdxE,
                        string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1,
                            t,
                            prevExpr.ReturnType
                            ));
                }

                ctx.NextIndex();

                IExpr nextExpr;
                while (true)
                {
                    nextExpr = next();
                    ThrowIfExprIsNull(nextExpr, t);

                    if (nextExpr.ReturnType == Enums.Type.Bool)
                    {
                        break;
                    }

                    ctx.PushExpr(nextExpr);
                }

                ctx.PopExpr();

                return new LogicalExpr(Env) { Token = t, A = prevExpr, B = nextExpr, };
            }

            return null;
        }
    }
}
