using CalculationService.Exceptions;
using CalculationService.Interfaces;
using System;

namespace CalculationService
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
                throw new CodeBuildEx(token.IdxS, token.IdxE,
                    string.Format(
                        tr.unexpected_token__0, token
                        ));
            }
        }

        public void ThrowIf(IToken token, Predicate<IToken> predicate)
        {
            if (predicate(token))
            {
                throw new CodeBuildEx(token.IdxS, token.IdxE,
                    string.Format(
                        tr.unexpected_token__0, token
                        ));
            }
        }
    }
}
