using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tokens
{
    public class NumberToken : Token
    {
        public NumberInfo Number { get; set; }

        public override string ToString() => Number.ToString();
    }
}
