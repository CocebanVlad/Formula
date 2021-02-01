using CalculationService.Exceptions;
using CalculationService.Expressions;
using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.ExpressionBuilders
{
    public class FuncExprBuilder : ExprBuilder
    {
        public FuncExprBuilder(IEnv env)
            : base(env)
        {
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is LiteralToken t)
            {
                var func = Env.GetFunc(t.String);
                if (func == null)
                {
                    throw new CodeBuildEx(t.IdxS, t.IdxE,
                        string.Format(
                            tr.the_name__0__does_not_exist_in_the_current_environment,
                            t.String
                            ));
                }

                ctx.NextIndex();

                var funcExpr = new FuncExpr(Env) { Token = t, Func = func };

                ThrowIf(ctx.Token, token => !(ctx.Token is ParenthesisToken openT) || !openT.IsOpen);

                funcExpr.ArgsBlockOpenToken = (ParenthesisToken)ctx.Token;

                ctx.NextIndex();

                IExpr expr;
                while (true)
                {
                    expr = next();
                    ThrowIfExprIsNull(expr, ctx.Token);

                    if (ctx.Token is ParenthesisToken token && !token.IsOpen)
                    {
                        funcExpr.Args.Add(expr);
                        funcExpr.ArgsBlockCloseToken = token;
                        break;
                    }

                    if (ctx.Token is SeparatorToken)
                    {
                        funcExpr.Args.Add(expr);
                        ctx.NextIndex();
                        continue;
                    }

                    ctx.PushExpr(expr);
                }

                func.ValidateArgs(Env, funcExpr.Args);

                ctx.NextIndex();

                return funcExpr;
            }

            return null;
        }
    }
}
