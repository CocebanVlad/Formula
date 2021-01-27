using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class Expr : IExpr
    {
        public abstract int IdxS { get; }
        public abstract int IdxE { get; }
        public abstract Enums.Type ReturnType { get; }

        protected IEnv Env { get; }

        public Expr(IEnv env)
        {
            Env = env;
        }

        public abstract object Eval();
        public abstract string GetAsString();
    }
}
