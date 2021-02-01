namespace CalculationService.Interfaces
{
    public interface ICanBeUsedAsNumber : IExpr
    {
        double GetAsNumber();
    }
}
