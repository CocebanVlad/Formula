using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tokens
{
    public class LiteralToken : Token
    {
        public string String { get; set; }

        public override string ToString() => String;
    }
}
