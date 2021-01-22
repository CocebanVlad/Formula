using System;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class GroupExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ParenthesisToken openT && openT.IsOpen)
            {
                ctx.MoveToTheNextIndex();

                IExpr innerExpr;
                ParenthesisToken closeT;
                while (true)
                {
                    innerExpr = next();
                    ThrowIfExprIsNull(innerExpr, openT);

                    if (ctx.Token is ParenthesisToken token && !token.IsOpen)
                    {
                        closeT = token;
                        break;
                    }

                    ctx.BuiltExpressions.Add(innerExpr);
                }

                ctx.MoveToTheNextIndex();
                return new GroupExpr() { OpenToken = openT, CloseToken = closeT, InnerExpr = innerExpr, };
            }

            return null;
        }
    }
}
