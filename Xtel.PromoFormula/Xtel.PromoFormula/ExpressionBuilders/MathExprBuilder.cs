using System;
using System.Linq;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class MathExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ArithmeticSymbolToken token)
            {
                if (initiator is MathExprBuilder)
                {
                    return null;
                }

                if (ctx.BuiltExpressions.Count == 0)
                {
                    return null;
                }

                var prevExpr =
                    ctx.BuiltExpressions.Last();
                if (prevExpr.ReturnType == Constants.NUMBER_TYPE)
                {
                    ctx.MoveToTheNextIndex();

                    var nextExpr = next();
                    ThrowIfExprIsNull(nextExpr, token);

                    if (nextExpr.ReturnType == Constants.NUMBER_TYPE)
                    {
                        ctx.BuiltExpressions
                            .RemoveAt(ctx.BuiltExpressions.Count - 1);

                        var mathExpr = new MathExpr() { Token = token, A = prevExpr, B = nextExpr };

                        if (prevExpr is MathExpr prevMathExpr &&
                            Helpers.GetArithmeticOperationPriority(token.Operation) > Helpers.GetArithmeticOperationPriority(prevMathExpr.Token.Operation))
                        {
                            // rearrange expressions based on operation priority: e.g. "((1 + 1) * 10)" -> "(1 + (1 * 10))"
                            mathExpr.A = prevMathExpr.B;
                            prevMathExpr.B = mathExpr;

                            // keep previous math expression as the principal one
                            mathExpr = prevMathExpr;
                        }

                        return mathExpr;
                    }
                }
            }

            return null;
        }
    }
}
