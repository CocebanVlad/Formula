using CalculationService.Expressions;
using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.ExpressionBuilders
{
    public class GroupExprBuilder : ExprBuilder
    {
        public GroupExprBuilder(IEnv env)
            : base(env)
        {
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ParenthesisToken openT && openT.IsOpen)
            {
                ctx.NextIndex();

                IExpr innerExpr;
                ParenthesisToken closeT;
                while (true)
                {
                    innerExpr = next();
                    ThrowIfExprIsNull(innerExpr, ctx.Token);

                    if (ctx.Token is ParenthesisToken token && !token.IsOpen)
                    {
                        closeT = token;
                        break;
                    }

                    ctx.PushExpr(innerExpr);
                }

                ctx.NextIndex();

                return new GroupExpr(Env) { OpenToken = openT, CloseToken = closeT, InnerExpr = innerExpr, };
            }

            return null;
        }
    }
}
