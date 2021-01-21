using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class BuildingPipeline : IBuildingPipeline
    {
        protected abstract IList<IExprBuilder> Builders { get; }

        protected virtual IExpr Cycle(BuildContext context, IExprBuilder initiator = null)
        {
            for (var idx = 0; idx < Builders.Count; idx++)
            {
                var expr = Builders[idx].Build(context, initiator, () => Cycle(context, Builders[idx]));
                if (expr != null)
                {
                    return expr;
                }
            }

            return null;
        }

        public virtual IList<IExpr> Build(IList<IToken> tokens)
        {
            var ctx = new BuildContext()
            {
                Tokens = tokens,
                BuiltExpressions = new List<IExpr>(),
            };

            while (ctx.HasToken())
            {
                var expr = Cycle(ctx);
                if (expr != null)
                {
                    ctx.BuiltExpressions.Add(expr);
                    continue;
                }

                if (ctx.Index >= ctx.Tokens.Count)
                {
                    break;
                }

                throw new BuildEx(ctx.Token.IdxS, ctx.Token.IdxE, $"Unexpected token: {ctx.Token}");
            }

            return ctx.BuiltExpressions;
        }
    }
}
