using System.Collections.Generic;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class BuildingPipeline : IBuildingPipeline
    {
        protected abstract IList<IExprBuilder> Builders { get; }

        protected IEnv Env { get; }

        public BuildingPipeline(IEnv env)
        {
            Env = env;
        }

        protected virtual IExpr Cycle(BuildContext ctx, IExprBuilder initiator = null)
        {
            for (var idx = 0; idx < Builders.Count; idx++)
            {
                var expr = Builders[idx].Build(ctx, initiator, () => Cycle(ctx, Builders[idx]));
                if (expr != null)
                {
                    return expr;
                }
            }

            return null;
        }

        public virtual IList<IExpr> Build(IList<IToken> tokens)
        {
            var ctx = new BuildContext(tokens);

            while (ctx.HasToken)
            {
                var expr = Cycle(ctx);
                if (expr != null)
                {
                    ctx.PushExpr(expr);
                    continue;
                }

                if (ctx.Idx >= ctx.Tokens.Count)
                {
                    break;
                }

                throw new BuildEx(ctx.Token.IdxS, ctx.Token.IdxE, string.Format(
                    tr.unexpected_token__0, ctx.Token));
            }

            return ctx.BuiltExprs;
        }
    }
}
