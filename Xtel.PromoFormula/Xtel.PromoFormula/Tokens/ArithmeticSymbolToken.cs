using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Enums;

namespace Xtel.PromoFormula.Tokens
{
    public class ArithmeticSymbolToken : Token
    {
        public ArithmeticOperation Operation { get; set; }

        public override string ToString()
        {
            switch (Operation)
            {
                case ArithmeticOperation.Add:
                    return "+";
                case ArithmeticOperation.Subtract:
                    return "-";
                case ArithmeticOperation.Multiply:
                    return "*";
                case ArithmeticOperation.Divide:
                    return "/";
                case ArithmeticOperation.Mod:
                    return "%";
            }

            throw new Exception($"Unknown operation: ArithmeticOperation.{Operation}");
        }
    }
}
