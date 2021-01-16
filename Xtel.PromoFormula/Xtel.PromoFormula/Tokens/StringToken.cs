using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tokens
{
    public class StringToken : Token
    {
        public string String { get; set; }
        public char NotationChar { get; set; }

        public override string ToString() => NotationChar + String + NotationChar;
    }
}
