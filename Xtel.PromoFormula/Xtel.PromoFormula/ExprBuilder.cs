using System;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class ExprBuilder : IExprBuilder
    {
        protected IEnv Env { get; }

        public ExprBuilder(IEnv env)
        {
            Env = env;
        }

        public abstract IExpr Build(BuildContext ctx, IExprBuilder initiator, Func<IExpr> next);

        public void ThrowIfExprIsNull(IExpr expr, IToken token)
        {
            if (expr == null)
            {
                throw new BuildEx(token.IdxS, token.IdxE,
                    string.Format(
                        tr.unexpected_token__0, token
                        ));
            }
        }

        public void ThrowIf(IToken token, Predicate<IToken> predicate)
        {
            if (predicate(token))
            {
                throw new BuildEx(token.IdxS, token.IdxE,
                    string.Format(
                        tr.unexpected_token__0, token
                        ));
            }
        }
    }
}
