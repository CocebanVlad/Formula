namespace CalculationService.Interfaces
{
    public interface ICanBePrefixedWithMinus : IExpr
    {
        object ApplyMinus();
    }
}
