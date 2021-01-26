using System;
using System.Linq;
using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class MathExprBuilder : ExprBuilder
    {
        private readonly bool _applyStringConcatOptimization;

        public MathExprBuilder(bool applyStringConcatOptimization)
        {
            _applyStringConcatOptimization = applyStringConcatOptimization;
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ArithmeticSymbolToken t)
            {
                if (initiator is MathExprBuilder || ctx.BuiltExpressions.Count == 0)
                {
                    return null;
                }

                var prevExpr =
                    ctx.BuiltExpressions.Last();

                IMathExprSuperior superior = null;
                if (prevExpr is IMathExprSuperior)
                {
                    superior = (IMathExprSuperior)prevExpr;
                    prevExpr = superior.B;
                }

                if (prevExpr.ReturnType != Constants.NumberType)
                {
                    throw new BuildEx(t.IdxS, t.IdxE,
                        string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1,
                            t,
                            prevExpr.ReturnType
                            ));
                }

                ctx.MoveToTheNextIndex();

                var nextExpr = next();
                ThrowIfExprIsNull(nextExpr, t);

                if (nextExpr.ReturnType != Constants.NumberType)
                {
                    if (_applyStringConcatOptimization)
                    {
                        if (t.Operation == ArithmeticOperation.Add)
                        {
                            // `StringConcatExprBuilder` will only build an expr if A has a string return type
                            if (nextExpr.ReturnType == Constants.StringType)
                            {
                                ctx.BuiltExpressions
                                    .RemoveAt(ctx.BuiltExpressions.Count - 1);

                                return new StringConcatExpr() { Token = t, A = prevExpr, B = nextExpr, };
                            }
                        }
                    }

                    throw new BuildEx(t.IdxS, t.IdxE,
                        string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1,
                            t,
                            nextExpr.ReturnType
                            ));
                }

                ctx.BuiltExpressions
                    .RemoveAt(ctx.BuiltExpressions.Count - 1);

                var mathExpr = new MathExpr() { Token = t, A = prevExpr, B = nextExpr };

                if (prevExpr is MathExpr prevMathExpr &&
                        Helpers.GetArithmeticOperationPriority(t.Operation) >
                        Helpers.GetArithmeticOperationPriority(prevMathExpr.Token.Operation)
                        )
                {
                    // rearrange expressions based on operation priority: e.g. "((1 + 1) * 10)" -> "(1 + (1 * 10))"
                    mathExpr.A = prevMathExpr.B;
                    prevMathExpr.B = mathExpr;

                    // keep previous math expression as the principal one
                    mathExpr = prevMathExpr;
                }

                if (superior != null)
                {
                    superior.B = mathExpr;
                    return superior;
                }
                else
                {
                    return mathExpr;
                }
            }

            return null;
        }
    }
}
