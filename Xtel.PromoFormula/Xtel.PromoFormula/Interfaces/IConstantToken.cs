namespace Xtel.PromoFormula.Interfaces
{
    public interface IConstantToken : IToken
    {
        string ConstValueType { get; }
        object ConstValue { get; }
        string ConstValueAsString { get; }
    }
}
