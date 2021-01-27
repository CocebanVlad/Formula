using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class NumberToken : Token, IConstantToken
    {
        public double Number { get; set; }

        public Enums.Type ConstValueType => Enums.Type.Number;
        public object ConstValue => Number;
        public string ConstValueAsString => Number.ToString(Helpers.GetNumberFormatProvider());

        public override string ToString() => ConstValueAsString;
    }
}
