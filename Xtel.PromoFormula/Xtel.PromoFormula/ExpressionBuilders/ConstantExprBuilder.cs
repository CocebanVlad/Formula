using System;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class ConstantExprBuilder : ExprBuilder
    {
        public ConstantExprBuilder(IEnv env)
            : base(env)
        {
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is IConstantToken t)
            {
                ctx.NextIndex();

                return ConstantExprFactory.Create(t, Env);
            }

            return null;
        }
    }
}
