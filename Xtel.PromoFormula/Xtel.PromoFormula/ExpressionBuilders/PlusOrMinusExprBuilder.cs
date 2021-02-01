using System;
using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class PlusOrMinusExprBuilder : ExprBuilder
    {
        public PlusOrMinusExprBuilder(IEnv env)
            : base(env)
        {
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ArithmeticSymbolToken t
                && (t.Operation == ArithmeticOperation.Add || t.Operation == ArithmeticOperation.Subtract))
            {
                ctx.NextIndex();

                var nextExpr = next();
                ThrowIfExprIsNull(nextExpr, t);

                if (nextExpr is ICanBePrefixedWithPlusOrMinus expr)
                {
                    if (!Helpers.TypesMatch(expr.ReturnType, Enums.Type.Number))
                    {
                        throw new BuildEx(t.IdxS, expr.IdxE,
                            string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1,
                                t,
                                expr.ReturnType
                                ));
                    }

                    return new PlusOrMinusExpr(Env) { Token = t, Expr = expr, };
                }
            }

            return null;
        }
    }
}
