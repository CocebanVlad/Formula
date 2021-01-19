using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tokens
{
    public class NumberToken : Token
    {
        public double Number { get; set; }

        public override string ToString() => Number.ToString();
    }
}
