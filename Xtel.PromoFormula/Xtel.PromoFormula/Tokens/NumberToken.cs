using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class NumberToken : Token, IConstantToken
    {
        public double Number { get; set; }

        public string ConstValueType => Constants.NUMBER_TYPE;
        public object ConstValue => Number;

        public override string ToString() => Number.ToString();
    }
}
