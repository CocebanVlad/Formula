using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tokens
{
    public class BoolToken : Token, IConstantToken
    {
        public bool Value { get; set; }

        public string ConstValueType => Constants.BOOL_TYPE;
        public object ConstValue => Value;

        public override string ToString() => Value ? "true" : "false";
    }
}
