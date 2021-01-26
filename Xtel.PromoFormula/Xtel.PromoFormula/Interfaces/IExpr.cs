namespace Xtel.PromoFormula.Interfaces
{
    public interface IExpr
    {
        int IdxS { get; }
        int IdxE { get; }
        string ReturnType { get; }

        object Eval(IEvalEnv env);
        string GetAsString(IEvalEnv env);
    }
}
