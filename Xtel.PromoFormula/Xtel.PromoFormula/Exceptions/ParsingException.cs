using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Exceptions
{
    public class ParsingException : Exception
    {
        public int Idx { get; set; }

        public ParsingException(int idx)
            : base()
        {
            Idx = idx;
        }

        public ParsingException(int idx, string msg)
            : base(msg)
        {
            Idx = idx;
        }

        public ParsingException(int idx, string msg, Exception ex)
            : base(msg, ex)
        {
            Idx = idx;
        }
    }
}
