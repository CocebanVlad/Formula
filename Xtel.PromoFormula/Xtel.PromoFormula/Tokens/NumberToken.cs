using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class NumberToken : Token, IConstantToken
    {
        public double Number { get; set; }

        public object GetValue() => Number;

        public override string ToString() => Number.ToString();
    }
}
