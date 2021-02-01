using CalculationService.Exceptions;
using CalculationService.Expressions;
using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.ExpressionBuilders
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
                if (!Helpers.TypesMatch(prevExpr.ReturnType, Enums.Type.Bool))
                {
                    throw new CodeBuildEx(t.IdxS, t.IdxE,
                        string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1,
                            t,
                            prevExpr.ReturnType
                            ));
                }

                ctx.NextIndex();

                var hasB = false;

                IExpr nextExpr;
                while (true)
                {
                    nextExpr = next();

                    if (!hasB)
                    {
                        ThrowIfExprIsNull(nextExpr, t);
                    }

                    if (nextExpr == null)
                    {
                        break;
                    }

                    hasB = true;
                    ctx.PushExpr(nextExpr);
                }

                nextExpr = ctx.PopExpr(); // nextExpr

                ctx.PopExpr(); // prevExpr

                return new LogicalExpr(Env) { Token = t, A = prevExpr, B = nextExpr, };
            }

            return null;
        }
    }
}
