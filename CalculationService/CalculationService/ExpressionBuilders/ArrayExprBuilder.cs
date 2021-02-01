using CalculationService.Expressions;
using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.ExpressionBuilders
{
    public class ArrayExprBuilder : ExprBuilder
    {
        public ArrayExprBuilder(IEnv env)
            : base(env)
        {
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ArrayParenthesisToken openT && openT.IsOpen)
            {
                ctx.NextIndex();

                var arrayExpr = new ArrayExpr(Env) { OpenToken = openT, };

                IExpr expr;
                while (true)
                {
                    expr = next();
                    ThrowIfExprIsNull(expr, ctx.Token);

                    if (ctx.Token is ArrayParenthesisToken token && !token.IsOpen)
                    {
                        arrayExpr.Elements.Add(expr);
                        arrayExpr.CloseToken = token;
                        break;
                    }

                    if (ctx.Token is SeparatorToken)
                    {
                        arrayExpr.Elements.Add(expr);
                        ctx.NextIndex();
                        continue;
                    }

                    ctx.PushExpr(expr);
                }

                ctx.NextIndex();

                arrayExpr.IdentifyExactReturnType();
                return arrayExpr;
            }

            return null;
        }
    }
}
