using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class BoolToken : Token, IConstantToken
    {
        public bool Value { get; set; }

        public string ConstValueType => Constants.BoolType;
        public object ConstValue => Value;
        public string ConstValueAsString => Value ? Constants.BoolTrueValue : Constants.BoolFalseValue;

        public override string ToString() => ConstValueAsString;
    }
}
