namespace Xtel.PromoFormula.Interfaces
{
    public interface ICanBeUsedAsBool : IExpr
    {
        bool GetAsBool(IEvalEnv env);
    }
}
