using System;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class StringConcatExprBuilder : ExprBuilder // must be enqueued before `MathExprBuilder`
    {
        private readonly bool _applyOptimization;

        public StringConcatExprBuilder(bool applyOptimization, IEnv env)
            : base(env)
        {
            _applyOptimization = applyOptimization; // `MathExprBuilder` should return a `StringConcatExpr` whenever B is of a `string` type
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ArithmeticSymbolToken t && t.Operation == Enums.ArithmeticOperation.Add)
            {
                if (initiator is StringConcatExprBuilder || ctx.BuiltExprs.Count == 0)
                {
                    return null;
                }

                var prevExpr = ctx.LastExpr;
                if (prevExpr.ReturnType == Enums.Type.String)
                {
                    ctx.NextIndex();

                    var nextExpr = next();
                    ThrowIfExprIsNull(nextExpr, t);

                    ctx.PopExpr();

                    return new StringConcatExpr(Env) { Token = t, A = prevExpr, B = nextExpr, };
                }
                else
                {
                    if (!_applyOptimization) // try to find if B contains a string (has high computational cost)
                    {
                        var ctxCopy = ctx.CreateCopy();

                        ctx.NextIndex();

                        var nextExpr = next();
                        ThrowIfExprIsNull(nextExpr, t);

                        if (nextExpr.ReturnType == Enums.Type.String)
                        {
                            ctx.PopExpr();

                            return new StringConcatExpr(Env) { Token = t, A = prevExpr, B = nextExpr, };
                        }

                        ctx.RestoreFrom(ctxCopy);
                    }
                }
            }

            return null;
        }
    }
}
