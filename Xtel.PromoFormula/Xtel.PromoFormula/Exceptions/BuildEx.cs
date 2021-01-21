using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Exceptions
{
    public class BuildEx : Ex
    {
        public BuildEx(int idxS)
            : base(idxS)
        {
        }

        public BuildEx(int idxS, int idxE)
            : base(idxS, idxE)
        {
        }

        public BuildEx(int idxS, string msg)
            : base(idxS, msg)
        {
        }

        public BuildEx(int idxS, int idxE, string msg)
            : base(idxS, idxE, msg)
        {
        }
    }
}
