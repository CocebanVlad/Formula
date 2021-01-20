using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface ITokenizer
    {
        IList<IToken> Tokenize(in string str);
    }
}
