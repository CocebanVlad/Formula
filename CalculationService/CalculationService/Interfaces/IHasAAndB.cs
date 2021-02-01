namespace CalculationService.Interfaces
{
    public interface IHasAAndB : IExpr
    {
        IExpr A { get; set; }
        IExpr B { get; set; }
    }
}
