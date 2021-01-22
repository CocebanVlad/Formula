using System.Collections.Generic;

namespace Xtel.PromoFormula.Interfaces
{
    public interface ITokenizer
    {
        IList<IToken> Tokenize(in string str);
    }
}
