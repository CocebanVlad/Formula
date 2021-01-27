using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class StringToken : Token, IConstantToken
    {
        public string String { get; set; }
        public char NotationChar { get; set; }

        public Enums.Type ConstValueType => Enums.Type.String;
        public object ConstValue => String;
        public string ConstValueAsString => String;

        public override string ToString() => NotationChar + String + NotationChar;
    }
}
