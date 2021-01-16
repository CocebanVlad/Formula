using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tokens
{
    public class SeparatorToken : Token
    {
        public char Symbol { get; set; }

        public override string ToString() => Symbol.ToString();
    }
}
