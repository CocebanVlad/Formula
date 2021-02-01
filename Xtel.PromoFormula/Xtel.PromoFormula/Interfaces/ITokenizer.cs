using System.Collections.Generic;

namespace CalculationService.Interfaces
{
    public interface ITokenizer
    {
        IList<IToken> Tokenize(in string str);
    }
}
