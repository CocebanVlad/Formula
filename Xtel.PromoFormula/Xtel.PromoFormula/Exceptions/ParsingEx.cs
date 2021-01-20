using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Exceptions
{
    public class ParsingEx : Exception
    {
        public int IdxS { get; set; }
        public int IdxE { get; set; }

        public ParsingEx(int idxS, int idxE)
            : base()
        {
            IdxS = idxS;
            IdxE = idxE;
        }

        public ParsingEx(int idxS)
            : base()
        {
            IdxS = idxS;
            IdxE = idxS + 1;
        }

        public ParsingEx(int idxS, int idxE, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxE;
        }

        public ParsingEx(int idxS, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxS + 1;
        }
    }
}
