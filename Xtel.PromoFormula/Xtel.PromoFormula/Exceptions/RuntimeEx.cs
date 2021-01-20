using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Exceptions
{
    public class RuntimeEx : Exception
    {
        public int IdxS { get; set; }
        public int IdxE { get; set; }

        public RuntimeEx(int idxS, int idxE)
            : base()
        {
            IdxS = idxS;
            IdxE = idxE;
        }

        public RuntimeEx(int idxS)
            : base()
        {
            IdxS = idxS;
            IdxE = idxS + 1;
        }

        public RuntimeEx(int idxS, int idxE, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxE;
        }

        public RuntimeEx(int idxS, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxS + 1;
        }
    }
}
