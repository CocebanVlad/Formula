using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Xtel.PromoFormula
{
    public class NumberInfo
    {
        public bool IsNegative { get; set; }
        public uint WholePart { get; set; }
        public uint FractionalPart { get; set; }
        public uint Exponent { get; set; }
        public bool HasNegativeExponent { get; set; }

        public NumberInfo()
        {
            IsNegative = false;
            WholePart = 0;
            FractionalPart = 0;
            Exponent = 0;
            HasNegativeExponent = false;
        }

        public override string ToString()
        {
            var bldr = new StringBuilder();

            if (IsNegative)
            {
                bldr.Append('-');
            }

            bldr.Append(WholePart);

            if (FractionalPart > 0)
            {
                bldr.Append('.');
                bldr.Append(FractionalPart);
            }

            if (Exponent > 0)
            {
                bldr.Append('e');
                bldr.Append(HasNegativeExponent ? '-' : '+');
                bldr.Append(Exponent);
            }

            return bldr.ToString();
        }

        public double ToDouble()
        {
            return double.Parse(ToString(), new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            });
        }
    }
}
