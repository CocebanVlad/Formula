namespace Xtel.PromoFormula.Interfaces
{
    public interface ICanBeUsedAsNumber : IExpr
    {
        double GetAsNumber();
    }
}
