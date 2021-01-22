using System;

namespace Xtel.PromoFormula.Exceptions
{
    public class Ex : Exception
    {
        public int IdxS { get; set; }
        public int IdxE { get; set; }

        public Ex(int idxS, int idxE)
            : base()
        {
            IdxS = idxS;
            IdxE = idxE;
        }

        public Ex(int idxS)
            : base()
        {
            IdxS = idxS;
            IdxE = idxS + 1;
        }

        public Ex(int idxS, int idxE, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxE;
        }

        public Ex(int idxS, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxS + 1;
        }
    }
}
