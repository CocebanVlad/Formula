using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tokens
{
    public class ArithmeticSymbolToken : Token
    {
        public char Symbol { get; set; }

        public override string ToString() => Symbol.ToString();
    }
}
