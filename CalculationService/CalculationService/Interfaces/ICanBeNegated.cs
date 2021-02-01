namespace CalculationService.Interfaces
{
    public interface ICanBeNegated : IExpr
    {
        object Negate();
    }
}
