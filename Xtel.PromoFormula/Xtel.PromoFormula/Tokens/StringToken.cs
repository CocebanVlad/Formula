using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class StringToken : Token, IConstantToken
    {
        public string String { get; set; }
        public char NotationChar { get; set; }

        public string ConstValueType => Constants.StringType;
        public object ConstValue => String;
        public string ConstValueAsString => String;

        public override string ToString() => NotationChar + String + NotationChar;
    }
}
