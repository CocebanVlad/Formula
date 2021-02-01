namespace CalculationService.Interfaces
{
    public interface IExpr
    {
        int IdxS { get; }
        int IdxE { get; }
        Enums.Type ReturnType { get; }

        object Eval();
        string GetAsString();
    }
}
