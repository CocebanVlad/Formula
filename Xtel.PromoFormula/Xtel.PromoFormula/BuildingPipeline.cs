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

        protected virtual IExpr Cycle(BuildContext context, int initBuilder)
        {
            initBuilder %= Builders.Count;

            for (var idx = 0; idx < Builders.Count; idx++)
            {
                var builder = (initBuilder + idx) % Builders.Count;
                var expr = Builders[builder].Build(context, () => Cycle(context, initBuilder + 1));
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
                var built = false;

                for (var idx = 0; idx < Builders.Count; idx++)
                {
                    var expr = Cycle(ctx, idx);
                    if (expr != null)
                    {
                        built = true;
                        ctx.BuiltExpressions.Add(expr);
                        break;
                    }
                }

                if (built)
                {
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
