using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class BoolToken : Token, IConstantToken
    {
        public bool Value { get; set; }

        public Enums.Type ConstValueType => Enums.Type.Bool;
        public object ConstValue => Value;
        public string ConstValueAsString => Value ? "true" : "false";

        public override string ToString() => ConstValueAsString;
    }
}
