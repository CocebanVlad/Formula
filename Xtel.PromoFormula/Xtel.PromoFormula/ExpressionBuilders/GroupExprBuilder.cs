using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Expressions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.ExpressionBuilders
{
    public class GroupExprBuilder : ExprBuilder
    {
        public override IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next)
        {
            if (ctx.Token is ParenthesisToken openToken && openToken.IsOpen)
            {
                ctx.MoveToTheNextIndex();

                IExpr innerExpr;
                ParenthesisToken closeToken;
                while (true)
                {
                    innerExpr = next();
                    ThrowIfExprIsNull(innerExpr, openToken);

                    if (ctx.Token is ParenthesisToken token && !token.IsOpen)
                    {
                        closeToken = token;
                        break;
                    }

                    ctx.BuiltExpressions.Add(innerExpr);
                }

                ctx.MoveToTheNextIndex();
                return new GroupExpr() { OpenToken = openToken, CloseToken = closeToken, InnerExpr = innerExpr, };
            }

            return null;
        }
    }
}
