using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class Expr : IExpr
    {
        public abstract int IdxS { get; }
        public abstract int IdxE { get; }
        public abstract string ReturnType { get; }

        public abstract object Eval(IEvalEnv env);
        public abstract string GetAsString(IEvalEnv env);
    }
}
