using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Exceptions;
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
                    if (innerExpr == null)
                    {
                        throw new BuildEx(openToken.IdxS, openToken.IdxE, $"Unexpected token: {openToken}");
                    }

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
