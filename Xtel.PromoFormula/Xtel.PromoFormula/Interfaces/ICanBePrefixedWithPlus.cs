namespace Xtel.PromoFormula.Interfaces
{
    public interface ICanBePrefixedWithPlus : IExpr
    {
        object ApplyPlus(IEvalEnv env);
    }
}
