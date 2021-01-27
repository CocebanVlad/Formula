using System;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class NegationExprBuilder : ExprBuilder
    {
        public NegationExprBuilder(IEnv env)
            : base(env)
        {
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is NegationToken t)
            {
                ctx.NextIndex();

                var nextExpr = next();
                ThrowIfExprIsNull(nextExpr, t);

                if (nextExpr is ICanBeNegated expr)
                {
                    if (expr.ReturnType != Enums.Type.Bool)
                    {
                        throw new BuildEx(t.IdxS, expr.IdxE,
                            string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1,
                                t,
                                expr.ReturnType
                                ));
                    }

                    return new NegationExpr(Env) { Token = t, Expr = expr, };
                }
            }

            return null;
        }
    }
}
