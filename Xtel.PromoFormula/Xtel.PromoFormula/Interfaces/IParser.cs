using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IParser
    {
        bool TryParse(in string str, int idxS, out int idxE, out IToken token);
    }
}
