namespace CalculationService.Interfaces
{
    public interface ICanBePrefixedWithPlus : IExpr
    {
        object ApplyPlus();
    }
}
