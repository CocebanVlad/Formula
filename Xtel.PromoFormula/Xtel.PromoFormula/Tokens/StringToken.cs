using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class StringToken : Token, IConstantToken
    {
        public string String { get; set; }
        public char NotationChar { get; set; }

        public object GetValue() => String;

        public override string ToString() => NotationChar + String + NotationChar;
    }
}
