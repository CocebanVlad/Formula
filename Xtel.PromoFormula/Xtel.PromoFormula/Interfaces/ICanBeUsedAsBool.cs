namespace CalculationService.Interfaces
{
    public interface ICanBeUsedAsBool : IExpr
    {
        bool GetAsBool();
    }
}
