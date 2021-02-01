using CalculationService.Exceptions;
using CalculationService.Expressions;
using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.ExpressionBuilders
{
    public class ConditionalExprBuilder : ExprBuilder
    {
        public ConditionalExprBuilder(IEnv env)
            : base(env)
        {
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ComparisonToken t)
            {
                if (initiator is ConditionalExprBuilder || ctx.BuiltExprs.Count == 0)
                {
                    return null;
                }

                var prevExpr = ctx.LastExpr;

                ctx.NextIndex();

                var nextExpr = next();
                ThrowIfExprIsNull(nextExpr, t);

                if (!Helpers.TypesMatch(prevExpr.ReturnType, nextExpr.ReturnType))
                {
                    throw new CodeBuildEx(t.IdxS, t.IdxE,
                        string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1__and__2,
                            t,
                            prevExpr.ReturnType,
                            nextExpr.ReturnType
                            ));
                }

                ctx.PopExpr();

                return new ConditionalExpr(Env) { Token = t, A = prevExpr, B = nextExpr, };
            }

            return null;
        }
    }
}
