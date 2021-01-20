using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class BoolToken : Token, IConstantToken
    {
        public bool Value { get; set; }

        public object GetValue() => Value;

        public override string ToString() => Value ? "true" : "false";
    }
}
