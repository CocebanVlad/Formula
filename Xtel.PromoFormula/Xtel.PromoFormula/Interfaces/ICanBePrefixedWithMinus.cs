namespace Xtel.PromoFormula.Interfaces
{
    public interface ICanBePrefixedWithMinus : IExpr
    {
        object ApplyMinus();
    }
}
