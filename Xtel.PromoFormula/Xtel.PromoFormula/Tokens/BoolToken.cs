using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tokens
{
    public class BoolToken : Token
    {
        public bool Value { get; set; }

        public override string ToString() => Value ? "true" : "false";
    }
}
