using CalculationService.Enums;
using CalculationService.Exceptions;
using CalculationService.Expressions;
using CalculationService.Interfaces;
using CalculationService.Tokens;
using System;

namespace CalculationService.ExpressionBuilders
{
    public class MathExprBuilder : ExprBuilder
    {
        private readonly bool _applyStringConcatOptimization;

        public MathExprBuilder(bool applyStringConcatOptimization, IEnv env)
            : base(env)
        {
            _applyStringConcatOptimization = applyStringConcatOptimization;
        }

        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ArithmeticSymbolToken t)
            {
                if (initiator is MathExprBuilder || ctx.BuiltExprs.Count == 0)
                {
                    return null;
                }

                var prevExpr = ctx.LastExpr;

                IMathExprSuperior superior = null;
                if (prevExpr is IMathExprSuperior)
                {
                    superior = (IMathExprSuperior)prevExpr;
                    prevExpr = superior.B;
                }

                if (!Helpers.TypesMatch(prevExpr.ReturnType, Enums.Type.Number))
                {
                    return null;
                }

                ctx.NextIndex();

                var nextExpr = next();
                ThrowIfExprIsNull(nextExpr, t);

                if (!Helpers.TypesMatch(nextExpr.ReturnType, Enums.Type.Number))
                {
                    if (_applyStringConcatOptimization)
                    {
                        if (t.Operation == ArithmeticOperation.Add)
                        {
                            // `StringConcatExprBuilder` will only build an expr if A has a string return type
                            if (nextExpr.ReturnType == Enums.Type.String)
                            {
                                ctx.PopExpr();

                                return new StringConcatExpr(Env) { Token = t, A = prevExpr, B = nextExpr, };
                            }
                        }
                    }

                    throw new CodeBuildEx(t.IdxS, t.IdxE,
                        string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type__1,
                            t,
                            nextExpr.ReturnType
                            ));
                }

                ctx.PopExpr();

                var mathExpr = new MathExpr(Env) { Token = t, A = prevExpr, B = nextExpr };

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
